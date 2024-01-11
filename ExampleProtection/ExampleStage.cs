using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Protections;
using ProwlynxNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProtection
{
    /// <summary>
    ///     An example stage that is a part of the <see cref="ExampleProtection" />
    /// </summary>
    public class ExampleStage : Stage
    {
        #region Public Properties

        // You do not have to inherit the protection priority field.
        // Inherit only when the stage has sub-stages.
        /// <inheritdoc />
        public override int ProtectionPriority { get; set; } = 999;

        /// <inheritdoc />
        public override int StagePriority { get; set; } = 4;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="ExampleStage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        public ExampleStage(IProtection parentProtection)
            : base(parentProtection)
        {
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void Process(ObfuscationTask t)
        {
            // Do some modifications to the module...
            t.Module.Name = "ExampleProtection_" + t.Module.Name;

            // Test out arguments given to the protection
            var argService = t.ArgumentProvider.GetService(GetType().Namespace);
            if (argService != null && argService.Has("test"))
            {
                t.Logger.LogInfo($"[{GetType().Name}] - Argument service results: 'test'='{argService["test"]}'");
            }

            // See what attribute arguments we have.
            var attrArgService = t.AttributeArgumentService;

            foreach (var td in t.Module.GetAllTypes())
            {
                var args = attrArgService.GetArguments(this, td);
                foreach (var arg in args)
                {
                    t.Logger.LogInfo($"[{GetType().Name}] - Attr Argument for {td.Name} - '{arg.Key}' = '{arg.Value}'");
                }
                foreach (var md in td.Methods)
                {
                    args = attrArgService.GetArguments(this, md);

                    foreach (var arg in args)
                    {
                        t.Logger.LogInfo($"[{GetType().Name}] - Attr Argument for {md.Name} - '{arg.Key}' = '{arg.Value}'");
                    }
                }
            }
        }

        #endregion
    }
}
