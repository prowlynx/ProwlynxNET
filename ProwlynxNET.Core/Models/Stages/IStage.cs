using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Stages
{
    /// <summary>
    ///     A protection stage that does not relate to writing. Most protections will have at least one of this stage type.
    /// </summary>
    public interface IStage : IProtectionStage
    {
        #region Public Methods

        /// <summary>
        ///     Process the stage.
        /// </summary>
        /// <param name="t">The obfuscation task currently being processed</param>
        void Process(ObfuscationTask t);

        #endregion
    }
}
