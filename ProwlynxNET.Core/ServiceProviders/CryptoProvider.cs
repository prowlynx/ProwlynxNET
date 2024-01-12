using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Services.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.ServiceProviders
{
    /// <summary>
    ///     The cryptography provider.
    /// </summary>
    public class CryptoProvider : ServiceProviderBase<ICryptoService>
    {
        /// <summary>
        /// Creates a new crypto provider which adds relevant <see cref="ICryptoService"/>'s. 
        /// </summary>
        public CryptoProvider()
        {
            Services.AddRange([
                new HashService(), 
                new AesService()
                ]);
        }
    }
}
