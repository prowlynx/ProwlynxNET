using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Protections;
using ProwlynxNET.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsmResolver.PE;

namespace ExampleProtection
{
    /// <summary>
    ///     An example metadata stage that is a part of the <see cref="ExampleProtection" />
    /// </summary>
    public class ExampleMDStage : MDStage
    {
        #region Public Properties

        /// <inheritdoc />
        public override int StagePriority { get; set; } = 3;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="ExampleMDStage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        public ExampleMDStage(IProtection parentProtection)
            : base(parentProtection)
        {

        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override void Process(ObfuscationTask t, IPEImage peImage)
        {
            t.Logger.LogDebug($"[{GetType().Name}] - Successfully called");
        }

        #endregion
    }
}
