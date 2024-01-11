using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Protections;
using ProwlynxNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsmResolver.DotNet;

namespace ExampleProtection
{
    /// <summary>
    ///     An example stage that uses the <see cref="InjectorService" />.
    /// </summary>
    public class ExampleInjectorStage : Stage
    {
        #region Public Properties

        /// <inheritdoc />
        public override int StagePriority { get; set; } = 1;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="ExampleInjectorStage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        public ExampleInjectorStage(IProtection parentProtection)
            : base(parentProtection)
        {
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void Process(ObfuscationTask t)
        {
            var dInfo = new DirectoryInfo(Path.GetDirectoryName(GetType().Assembly.Location) ??
                                          throw new ArgumentNullException());

            var thisModule = ModuleDefinition.FromFile(dInfo.FullName +
                                              $"\\{GetType().Namespace}.{(t.IsDotNetCoreModule ? "Core" : "FW")}.dll");
            var td = thisModule.GetAllTypes().First(x => x.FullName.Contains("ExampleProtection.InjectedType"));

            // Prepare it for adding to the new module.
            var preparedType = (TypeDefinition)t.Injector.Inject(td, t.Module!);
            preparedType.Name = "SuccessfullyInjectedType";
            preparedType.Namespace = "Injected";

            // Actually put it into the module.
            t.Module.TopLevelTypes.Add(preparedType);

            t.Logger.LogDebug($"[{GetType().Name}] Successfully injected");
        }

        #endregion
    }
}
