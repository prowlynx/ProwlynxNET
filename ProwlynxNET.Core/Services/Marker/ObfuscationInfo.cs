using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Marker
{
    /// <summary>
    ///     Information about a type/method definition in the target assembly and whether it can be processed by a
    ///     <see cref="IProtection" />.
    /// </summary>
    public class ObfuscationInfo : DefinitionInfo
    {
        #region Public Properties

        /// <summary>
        ///     The name of the <see cref="IProtection" />.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        ///     Whether to exclude the execution of the <see cref="Name" />.
        /// </summary>
        public required bool Exclude { get; set; }

        /// <summary>
        ///     Whether to apply the same rule to nested members (methods inside a type definition normally).
        /// </summary>
        public required bool ApplyToMembers { get; set; }

        #endregion
    }
}
