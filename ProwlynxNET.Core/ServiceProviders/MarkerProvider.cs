using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Services.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.ServiceProviders
{
    /// <summary>
    ///     The marker provider for the <see cref="MarkerService" />.
    /// </summary>
    public class MarkerProvider : ServiceProviderBase<IMarkerService>
    {
        #region Constructors

        /// <summary>
        ///     Create a new marker provider adding a single <see cref="MarkerService" /> service.
        /// </summary>
        public MarkerProvider()
        {
            // Just populate the marker.
            Services.Add(new MarkerService());
        }

        #endregion
    }
}
