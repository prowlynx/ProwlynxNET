using ProwlynxNET.Core.Extensions;
using ProwlynxNET.Core.Models.Services;
using System.Security.Cryptography;

namespace ProwlynxNET.Core.Services.Crypto
{
    /// <summary>
    /// A basic AES service with some customisability.
    /// </summary>
    public class AesService : ICryptoService
    {
        private byte[]? _keyBytes;
        /// <summary>
        /// The AES Key. When set, will derive a key from the bytes passed to it. 
        /// This is the true key, do not assume the key you give it will become the true key.
        /// </summary>
        public byte[]? Key 
        { 
            get
            {
                return _keyBytes;
            }
            set
            {
                _keyBytes = DeriveKey(value!, AesKeySize);
            }
        }

        /// <summary>
        /// The AES IV, this is randomly generated and prepended to the data every encryption.
        /// </summary>
        public byte[]? AdditionalData { get; set; }

        /// <inheritdoc />
        public string Name => nameof(AesService);

        /// <inheritdoc />
        public string Description => "Provides AES Services";

        /// <summary>
        /// The cipher mode to use when encrypting and decrypting.
        /// </summary>
        public CipherMode AesCipherMode { get; set; } = CipherMode.CBC;

        /// <summary>
        /// The Aes Key Size: 64, 128, 256.
        /// </summary>
        public int AesKeySize { get; set; } = 256;

        /// <summary>
        /// Encrypt using the set mode of AES.
        /// </summary>
        /// <param name="data">Raw data.</param>
        /// <returns>The encrypted bytes.</returns>
        public byte[] Encrypt(byte[] data)
        {
            if (Key == null)
            {
                throw new NullReferenceException(nameof(Key));
            }
            using (var aes = Aes.Create())
            {
                aes.Key = Key!;
                aes.KeySize = AesKeySize;
                aes.Mode = AesCipherMode;
                aes.Padding = PaddingMode.PKCS7;

                aes.GenerateIV();
                var iv = aes.IV;
                AdditionalData = iv;

                using (var encrypter = aes.CreateEncryptor(aes.Key, iv))
                using (var cipherStream = new MemoryStream())
                {
                    using (var tCryptoStream = new CryptoStream(cipherStream, encrypter, CryptoStreamMode.Write))
                    using (var tBinaryWriter = new BinaryWriter(tCryptoStream))
                    {
                        // prepend IV to data
                        cipherStream.Write(iv);
                        tBinaryWriter.Write(data);
                        tCryptoStream.FlushFinalBlock();
                    }
                    var cipherBytes = cipherStream.ToArray();

                    return cipherBytes;
                }
            }
        }

        /// <summary>
        /// Decrypt using the set mode of AES.
        /// </summary>
        /// <param name="data">Encrypted data.</param>
        /// <returns>The decrypted bytes.</returns>
        public byte[] Decrypt(byte[] data)
        {
            if (Key == null)
            {
                throw new NullReferenceException(nameof(Key));
            }
            using (var aes = Aes.Create())
            {
                aes.Key = Key!;
                aes.KeySize = AesKeySize;
                aes.Mode = AesCipherMode;
                aes.Padding = PaddingMode.PKCS7;

                // Get first KeySize bytes of IV and use it to decrypt
                // IV is always blocksize / 8.
                var iv = new byte[aes.BlockSize / 8];
                Array.Copy(data, 0, iv, 0, iv.Length);
                AdditionalData = iv;

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(aes.Key, iv), CryptoStreamMode.Write))
                    using (var binaryWriter = new BinaryWriter(cs))
                    {
                        // Decrypt cipher text from data, starting just past the IV
                        binaryWriter.Write(
                            data,
                            iv.Length,
                            data.Length - iv.Length
                        );
                    }

                    var dataBytes = ms.ToArray();
                    return dataBytes;
                }
            }
        }

        private byte[] DeriveKey(byte[] bytes, int size)
        {
            // Salt isn't great... think up another way, user supplies salt?
            using (Rfc2898DeriveBytes rb = new Rfc2898DeriveBytes(bytes, Utils.SHA256(bytes), 50000, HashAlgorithmName.SHA3_256))
            {
                return rb.GetBytes(size);
            }
        }
    }
}
