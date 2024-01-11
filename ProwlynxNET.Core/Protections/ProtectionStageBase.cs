using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProwlynxNET.Core.Models;

namespace ProwlynxNET.Core.Protections
{
    /// <summary>
    ///     Should not be directly inherited by a protection. Use the <see cref="Stage" /> or <see cref="MDStage" /> classes.
    /// </summary>
    public abstract class ProtectionStageBase : ProtectionBase, IProtectionStage
    {
        #region Public Properties

        // Since a protection stage can in itself be a protection
        // we can just inherit from protection base and IProtectionStage.

        /// <inheritdoc />
        public abstract int StagePriority { get; set; }

        /// <inheritdoc />
        public IProtection ParentProtection { get; set; }

        // Generally not needed, unless sub-stages are a thing in the stage.
        /// <inheritdoc />
        public override int ProtectionPriority { get; set; } = -1;

        /// <inheritdoc />
        public override string ProtectionName { get; set; } = "Unknown Parent Protection";

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new <see cref="ProtectionStageBase" /> owned by the specified protection.
        ///     Copying the protection name from the supplied protection.
        /// </summary>
        /// <param name="parentProtection">The parent protection.</param>
        protected ProtectionStageBase(IProtection parentProtection)
        {
            ParentProtection = parentProtection;

            // Borrow the protection name from the parent protection.
            // The parent could be a stage as well, but it'd still end up with the correct protection name.
            ProtectionName = ParentProtection.ProtectionName;
        }

        #endregion
    }
}
