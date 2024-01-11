using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Marker
{

    /// <summary>
    ///     A class for marker information.
    /// </summary>
    public class MarkerInfo
    {
        #region Public Properties

        /// <summary>
        ///     The obfuscation information for the <see cref="MarkerService" />.
        /// </summary>
        public List<ObfuscationInfo> Obfuscations { get; set; } = new List<ObfuscationInfo>();

        #endregion
    }
}
