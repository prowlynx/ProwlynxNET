using AsmResolver.DotNet;
using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Services.Marker;
using ProwlynxNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProwlynxNET.Extensions;
using AsmResolver.DotNet.Builder;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Builder;
using AsmResolver.PE;
using ProwlynxNET.Core.Protections;

namespace ProwlynxNET.Engine
{
    /// <summary>
    ///     A task runner to process <see cref="ObfuscationTask" />s.
    /// </summary>
    public class Obfuscator
    {
        #region Fields

        private readonly ConsoleLogger _logger;

        private readonly List<IProtection> _protections;
        private ObfuscationTask? _task;

        #endregion

        #region Constructors

        /// <summary>
        ///     Creates a new Obfuscator task runner.
        /// </summary>
        public Obfuscator()
        {
            _logger = new ConsoleLogger();
            _protections = [];

            LoadProtectionsFromDirectory(Environment.CurrentDirectory + "\\Protections");
            LoadProtectionsFromNamespace("ProwlynxNET.Protections");

            // Order protections by their priority.
            _protections = [.. _protections.OrderBy(p => p.ProtectionPriority)];
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Create a task from a module file path and return it.
        /// </summary>
        /// <param name="moduleFilePath">The fullpath to the module.</param>
        /// <returns>The created task, ready to be ran.</returns>
        public ObfuscationTask CreateTask(string moduleFilePath)
        {
            string outputFilePath = moduleFilePath.GetFilePath();
            var obfuscationTask = new ObfuscationTask(moduleFilePath, outputFilePath, new ConsoleLogger());

            //ResolveAssemblies(obfuscationTask);
            return obfuscationTask;
        }

        /// <summary>
        ///     Run an <see cref="ObfuscationTask" /> and write it to disk.
        /// </summary>
        /// <param name="task"></param>
        public void RunTask(ObfuscationTask task)
        {
            _task = task;

            // Read attributes.
            var attrReader = new AttributeReader();
            attrReader.Read(task);

            // Process protections.
            foreach (var protection in _protections) RunStages(protection);

            var imageBuilder = new ManagedPEImageBuilder();

            var factory = new DotNetDirectoryFactory();
            factory.MetadataBuilderFlags = MetadataBuilderFlags.PreserveAll;
            factory.MetadataBuilderFlags |= MetadataBuilderFlags.PreserveUnknownStreams;
            factory.MetadataBuilderFlags |= MetadataBuilderFlags.PreserveTableIndices;
            factory.MethodBodySerializer = new CilMethodBodySerializer
            {
                ComputeMaxStackOnBuildOverride = false
            };
            imageBuilder.DotNetDirectoryFactory = factory;

            var result = imageBuilder.CreateImage(task.Module!);
            if (result.HasFailed)
            {
                _logger.LogError($"Creating image has failed for {task.Module!.Name}.");
                return;
            }
            
            var image = result.ConstructedImage;
            var fileBuilder = new ManagedPEFileBuilder();
            var file = fileBuilder.CreateFile(image);

            // We need a temp location for processing metadata.
            // It is claimed this is not necessary, but in reality it is...
            var tempFilePath = Path.Combine(Environment.CurrentDirectory, Path.GetFileNameWithoutExtension(task.InputFile) + "_TEMP.dll");
            file.Write(tempFilePath);


            // Now we can re-read it and process metadata again.
            IPEImage peImage = PEImage.FromFile(tempFilePath);

            // Make module inaccessible.
            // MD Stages that want to access this can themselves serialize/deserialize down/up the layers of abstraction.
            _task!.Module = null;

            foreach (var protection in _protections)
                RunMDStages(protection, peImage);

            // Then finally write it to disk.
            fileBuilder = new ManagedPEFileBuilder();
            file = fileBuilder.CreateFile(peImage);

            // Delete the original file.
            File.Delete(task.OutputFile);

            file.Write(task.OutputFile);

        }

        #endregion

        #region Private Methods

        private void LoadProtectionsFromNamespace(string @namespace)
        {
            LoadPlugins(GetType().Assembly, t => t.Namespace != null && t.Namespace.Contains(@namespace));
        }

        private void LoadProtectionsFromDirectory(string directory)
        {
            if (!Directory.Exists(directory)) throw new DirectoryNotFoundException(nameof(directory));

            foreach (string file in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
                try
                {
                    if (file.EndsWith(".Core.dll") || file.EndsWith(".FW.dll"))
                        continue;
                    LoadPlugins(Assembly.LoadFile(file), t => true);
                }
                catch (BadImageFormatException ex)
                {
                    _logger.LogError($"Failed to load plugins from '{file}', BadImageFormat == File is Native? {ex}");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed with Exception '{file}': {ex}");
                }
        }

        private void LoadPlugins(Assembly assembly, Func<Type, bool> whereClause)
        {
            foreach (var protectionType in assembly
                                           .GetTypes()
                                           .Where(t =>
                                                      !t.IsInterface &&
                                                      !t.IsAbstract &&
                                                      typeof(IProtection).IsAssignableFrom(t) &&
                                                      !typeof(IProtectionStage).IsAssignableFrom(t)
                                           )
                                           .Where(whereClause)
            )
            {
                var protectionInstance = (IProtection)Activator.CreateInstance(protectionType)!;
                _protections.Add(protectionInstance);
                _logger.LogInfo($"{protectionInstance.ProtectionName} has been loaded");
            }
        }

        /// <summary>
        ///     Run regular <see cref="Stage" />s of the specified protection.
        /// </summary>
        /// <param name="protection">The protection to process stages of.</param>
        private void RunStages(IProtection protection)
        {
            foreach (var protectionStage in protection.GetStages<Stage>())
            {
                _task!.Logger.LogDebug($"[{GetType().Name}] - Running Stage {protectionStage.GetType().Name}");
                if (protectionStage.HasStages) RunStages(protectionStage);
                protectionStage.Process(_task);
            }
        }

        /// <summary>
        ///     Run the <see cref="MDStage" />s of the given protection.
        /// </summary>
        /// <param name="protection">The protection.</param>
        /// <param name="peImage">The PE Image with a metadata stream.</param>
        private void RunMDStages(IProtection protection, IPEImage peImage)
        {
            foreach (var protectionStage in protection.GetStages<MDStage>())
            {
                if (protectionStage.HasStages) RunMDStages(protectionStage, peImage);

                _task!.Logger.LogDebug($"[{GetType().Name}] - Running MD Stage {protectionStage.GetType().Name}");

                protectionStage.Process(_task, peImage);
            }
        }

        #endregion
    }
}
