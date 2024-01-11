using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.ServiceProviders
{
    /// <summary>
    ///     All service providers inherit from this class.
    /// </summary>
    /// <typeparam name="T">The type of service the service provider will provide</typeparam>
    public abstract class ServiceProviderBase<T> : IServiceProvider<T> where T : IService
    {
        #region Public Properties

        /// <inheritdoc />
        public List<T> Services { get; } = new List<T>();

        /// <summary>
        ///     Get the first service from the service list (or null).
        /// </summary>
        public T First => Services.FirstOrDefault()!;

        /// <summary>
        ///     Get the last service from the service list (or null).
        /// </summary>
        public T Last => Services.Last();

        /// <summary>
        ///     Get a service by index.
        /// </summary>
        /// <param name="index">The index of the service.</param>
        /// <returns></returns>
        public T this[int index] => Services[index];

        /// <summary>
        ///     Get a service by its <see cref="IService.Name" />.
        /// </summary>
        /// <param name="serviceName">The name of the service.</param>
        /// <returns></returns>
        public T this[string serviceName] => GetService(serviceName);

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public T GetService(string serviceName)
        {
            return Services.FirstOrDefault(service => service.Name == serviceName)!;
        }

        /// <inheritdoc />
        public void AddService(T service)
        {
            Services.Add(service);
        }

        #endregion
    }
}
