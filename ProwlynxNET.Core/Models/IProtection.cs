using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     A protection for the obfuscator, it has stages that modify the contents of the module.
    /// </summary>
    public interface IProtection
    {
        #region Public Properties

        /// <summary>
        ///     The name of the protection.
        /// </summary>
        string ProtectionName { get; set; }

        /// <summary>
        ///     The stages that operate on the module.
        /// </summary>
        List<IProtectionStage> Stages { get; set; }

        /// <summary>
        ///     The priority for this protection. A lower number is a higher priority.
        /// </summary>
        int ProtectionPriority { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Get the stages that are of type T.
        /// </summary>
        /// <typeparam name="T">The stage type</typeparam>
        /// <returns>The list of stages that are of type T</returns>
        List<T> GetStages<T>() where T : IProtectionStage;

        /// <summary>
        ///     Get the first stage (or null) that are of type T.
        /// </summary>
        /// <typeparam name="T">The stage type</typeparam>
        /// <returns>The first stage, or null of type T</returns>
        T? GetStage<T>() where T : IProtectionStage;

        #endregion
    }
}
