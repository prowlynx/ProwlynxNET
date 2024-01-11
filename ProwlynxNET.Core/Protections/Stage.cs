using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Models.Stages;

namespace ProwlynxNET.Core.Protections
{
    /// <summary>
    ///     Base of all regular stages that modify methods/modules/etc before writing beings.
    /// </summary>
    public abstract class Stage : ProtectionStageBase, IStage
    {
        #region Constructors

        /// <summary>
        ///     Create a new <see cref="Stage" /> owned by the specified protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        protected Stage(IProtection parentProtection)
            : base(parentProtection)
        {

        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public abstract void Process(ObfuscationTask t);

        #endregion
    }
}
