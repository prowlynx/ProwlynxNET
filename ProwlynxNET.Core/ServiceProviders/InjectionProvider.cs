using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Services.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.ServiceProviders
{
    /// <summary>
    ///     The injection provider for <see cref="InjectorService" />.
    /// </summary>
    public class InjectionProvider : ServiceProviderBase<IInjectionService>
    {
        #region Constructors

        /// <summary>
        ///     Create a new injection provider adding a single <see cref="InjectorService" /> service.
        /// </summary>
        public InjectionProvider()
        {
            // Just populate the marker.
            Services.Add(new InjectorService());
        }

        #endregion
    }
}
