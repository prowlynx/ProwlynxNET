using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     A protection stage that is a part of a protection.
    ///     Protection stages can also have sub-stages so protection stage inherits from <see cref="IProtection" />
    /// </summary>
    public interface IProtectionStage : IProtection
    {
        #region Public Properties

        /// <summary>
        ///     The priority for the stage. A lower number is a higher priority.
        /// </summary>
        int StagePriority { get; set; }

        /// <summary>
        ///     The protection that is directly the owner of the stage.
        /// </summary>
        IProtection ParentProtection { get; set; }

        #endregion
    }
}
