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
    ///     An example stage that checks methods for markings.
    /// </summary>
    public class ExampleMarkerStage : Stage
    {
        #region Public Properties

        /// <inheritdoc />
        public override int StagePriority { get; set; } = 2;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="ExampleMarkerStage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        public ExampleMarkerStage(IProtection parentProtection)
            : base(parentProtection)
        {
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void Process(ObfuscationTask t)
        {
            foreach (var td in t.Module.GetAllTypes())
            {
                t.Logger.LogDebug(t.Marker.CanProtect(this, td)
                                      ? $"[{GetType().Name}] - Can Protect Type {td.Name}"
                                      : $"[{GetType().Name}] - CANNOT Protect Type {td.Name}");

                foreach (var md in td.Methods)
                    t.Logger.LogDebug(t.Marker.CanProtect(this, md)
                                          ? $"[{GetType().Name}] - Can Protect Method {md.Name}"
                                          : $"[{GetType().Name}] - CANNOT Protect Method {md.Name}");
            }
        }

        #endregion
    }
}
