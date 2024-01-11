using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Services
{
    /// <summary>
    ///     A generic cryptography service.
    /// </summary>
    public interface ICryptoService : IService
    {
        #region Public Properties

        /// <summary>
        ///     The key for the cryptography operation
        /// </summary>
        byte[] Key { get; set; }

        /// <summary>
        ///     Sometimes an algorithm may require additional data, an IV for example.
        /// </summary>
        byte[] AdditionalData { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Encrypt a byte array
        ///     <param name="data">The data to encrypt</param>
        /// </summary>
        /// <returns>The encrypted byte array</returns>
        byte[] Encrypt(byte[] data);

        /// <summary>
        ///     Decrypt a byte array.
        ///     <param name="data">The data to decrypt (already encrypted)</param>
        /// </summary>
        /// <returns>The decrypted byte array</returns>
        byte[] Decrypt(byte[] data);

        #endregion
    }
}
