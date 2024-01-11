using ProwlynxNET.Core.Models;
using ProwlynxNET.Core.Protections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProtection
{
    // Please check out the post-build events in this project's properties!
    /// <summary>
    ///     An example protection.
    /// </summary>
    public class ExampleProtection : ProtectionBase
    {
        #region Public Properties

        /// <inheritdoc />
        public override string ProtectionName { get; set; } = "ExampleProtection";

        /// <inheritdoc />
        public override int ProtectionPriority { get; set; } = 1;

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new example protection, populating all stages.
        /// </summary>
        public ExampleProtection()
        {
            // Add a single stage
            Stages = new List<IProtectionStage>
            {
                new ExampleStage(this),
                new ExampleMarkerStage(this),
                new ExampleMDStage(this),
                new ExampleInjectorStage(this)
            };
        }

        #endregion
    }
}
