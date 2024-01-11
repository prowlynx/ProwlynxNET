using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     Provides a series of <see cref="IService" />.
    /// </summary>
    public interface IServiceProvider<T> where T : IService
    {
        #region Public Properties

        /// <summary>
        ///     The list of services the provider supplies
        /// </summary>
        List<T> Services { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Get a particular <see cref="IService" /> with the unique service name.
        /// </summary>
        /// <param name="serviceName">The service name</param>
        /// <returns>The related service, or null</returns>
        T GetService(string serviceName);

        /// <summary>
        ///     Add a service to the service list.
        /// </summary>
        /// <param name="service">The service to add.</param>
        void AddService(T service);

        #endregion
    }
}
