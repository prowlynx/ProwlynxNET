using ProwlynxNET.Core.Extensions;
using ProwlynxNET.Core.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Crypto
{
    /// <summary>
    /// Basic Hash Service class providing some mini functions.
    /// </summary>
    public class HashService : ICryptoService
    {
        /// <summary>
        /// Not implemented.
        /// </summary>
        public byte[]? Key { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// Not implemented.
        /// </summary>
        public byte[]? AdditionalData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <inheritdoc />
        public string Name => nameof(HashService);

        /// <inheritdoc />
        public string Description => "Provides hashing services";

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] Decrypt(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public byte[] Encrypt(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Provide a SHA1 Hash of the byte data.
        /// </summary>
        /// <param name="data">Data to hash</param>
        /// <returns>Hash bytes, use <see cref="Utils.ToHexString(byte[])"/> to retrieve a string.</returns>
        public byte[] SHA1Hash(byte[] data)
        {
            return Utils.SHA1(data);
        }

        /// <summary>
        /// Provide a SHA256 Hash of the byte data.
        /// </summary>
        /// <param name="data">Data to hash</param>
        /// <returns>Hash bytes, use <see cref="Utils.ToHexString(byte[])"/> to retrieve a string.</returns>
        public byte[] SHA256Hash(byte[] data)
        {
            return Utils.SHA256(data);
        }
    }
}
