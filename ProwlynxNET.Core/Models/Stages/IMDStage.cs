using AsmResolver.PE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Stages
{
    /// <summary>
    ///     A protection stage that relates to metadata/writing contents.
    /// </summary>
    public interface IMDStage : IProtectionStage
    { 
        #region Public Methods

        /// <summary>
        ///     Process the stage.
        /// </summary>
        /// <param name="t">The task, noting that Module is inaccessible (null).</param>
        /// <param name="peImage">The PE Image with DotNetDirectory.</param>
        void Process(ObfuscationTask t, IPEImage peImage);

        #endregion
    }
}
