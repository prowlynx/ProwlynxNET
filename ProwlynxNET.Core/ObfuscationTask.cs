using AsmResolver.DotNet;
using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.ServiceProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProwlynxNET.Core.Services.Argument;

namespace ProwlynxNET.Core
{
    /// <summary>
    ///     The obfuscation task.
    /// </summary>
    public class ObfuscationTask
    {
        #region Public Properties

        /// <summary>
        ///     The task identifier, unique per task.
        /// </summary>
        public Guid TaskID { get; }

        /// <summary>
        ///     The module for the task.
        /// </summary>
        public ModuleDefinition Module { get; set; }

        /// <summary>
        ///     The modules for the whole process
        /// </summary>
        public List<ModuleDefinition> Modules { get; set; }

        /// <summary>
        ///     Whether the <see cref="Module" /> is a .NET Core module.
        /// </summary>
        public bool IsDotNetCoreModule => Module != null && Module.CorLibTypeFactory.ExtractDotNetRuntimeInfo().IsNetCoreApp;

        /// <summary>
        ///     Whether the <see cref="Module" /> is a .NET Standard module.
        /// </summary>
        public bool IsDotNetStandardModule => Module != null && Module.CorLibTypeFactory.ExtractDotNetRuntimeInfo().IsNetStandard;

        /// <summary>
        ///     Whether the <see cref="Module" /> is a .NET Framework module.
        /// </summary>
        public bool IsDotNetFrameworkModule => Module != null && Module.CorLibTypeFactory.ExtractDotNetRuntimeInfo().IsNetFramework;

        /// <summary>
        ///     The assembly resolver for the module.
        /// </summary>
        public ReferenceImporter Resolver { get; set; }

        /// <summary>
        ///     The cryptography provider for the task.
        /// </summary>
        public CryptoProvider CryptoProvider { get; set; }

        /// <summary>
        ///     The marker provider for the task.
        /// </summary>
        public MarkerProvider MarkerProvider { get; set; }

        /// <summary>
        ///     The first <see cref="IMarkerService" /> from the <see cref="MarkerProvider" />.
        /// </summary>
        public IMarkerService Marker => MarkerProvider.First;

        /// <summary>
        ///     The injection provider for the task.
        /// </summary>
        public InjectionProvider InjectionProvider { get; set; }

        /// <summary>
        ///     The first <see cref="IInjectionService" /> from the <see cref="InjectionProvider" />.
        /// </summary>
        public IInjectionService Injector => InjectionProvider.First;

        /// <summary>
        ///     The attribute argument provider for the task.
        /// </summary>
        public AttributeArgumentProvider AttributeArgumentProvider { get; set; }

        /// <summary>
        ///     The first <see cref="IAttributeArgumentService" /> from the <see cref="AttributeArgumentProvider" />.
        /// </summary>
        public IAttributeArgumentService<ArgumentInfo> AttributeArgumentService => AttributeArgumentProvider.First;

        /// <summary>
        ///     The argument provider that provides arguments for <see cref="IProtection" />s.
        /// </summary>
        public ArgumentProvider ArgumentProvider { get; set; }

        /// <summary>
        ///     The output filepath, as requested.
        /// </summary>
        public string OutputFile { get; set; }

        /// <summary>
        ///     The input file path, as provided.
        /// </summary>
        public string InputFile { get; set; }

        /// <summary>
        ///     The logger to use when logging information.
        /// </summary>
        public ILogger Logger { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Creates a new obfuscation task and sets the InputFile, Module properties.
        /// </summary>
        /// <param name="inputFile">The full filepath to the input file.</param>
        /// <param name="outputFile">The output filepath.</param>
        /// <param name="logger">The <see cref="ILogger"/> instance.</param>
        public ObfuscationTask(string inputFile, string outputFile, ILogger logger)
        {
            InputFile = inputFile;

            TaskID = Guid.NewGuid();

            MarkerProvider = new MarkerProvider();
            InjectionProvider = new InjectionProvider();
            CryptoProvider = new CryptoProvider();
            ArgumentProvider = new ArgumentProvider();
            AttributeArgumentProvider = new AttributeArgumentProvider();

            Module = ModuleDefinition.FromFile(inputFile);
            Modules = [Module];

            // TODO: Perhaps customise this later and allow personal input.
            Resolver = Module.DefaultImporter;

            OutputFile = outputFile;
            Logger = logger;
        }

        #endregion
    }
}
