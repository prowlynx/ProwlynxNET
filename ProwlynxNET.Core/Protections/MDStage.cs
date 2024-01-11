using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsmResolver.PE;
using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Models.Stages;

namespace ProwlynxNET.Core.Protections
{
    /// <summary>
    ///     Base of all stages that change metadata or a PEImage being written.
    /// </summary>
    public abstract class MDStage : ProtectionStageBase, IMDStage
    {

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="MDStage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        protected MDStage(IProtection parentProtection)
            : base(parentProtection)
        {

        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public abstract void Process(ObfuscationTask t, IPEImage peImage);

        #endregion
    }
}
