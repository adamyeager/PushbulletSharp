using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Text;

namespace PushbulletSharp.Encryption
{
    public static class EncryptionUtility
    {
        private static readonly SecureRandom Random = new SecureRandom();
        private static readonly int KeyBitSize = 256;
        private static readonly int NonceBitSize = 96;
        private static readonly int TagBitSize = 128;

        #region Methods

        /// <summary>
        /// Generates the key.
        /// </summary>
        /// <param name="user_iden">The user iden.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static string GenerateKey(string user_iden, string password)
        {
            int keyLength = 32;
            int iterations = 30000;
            byte[] saltBytes = Encoding.UTF8.GetBytes(user_iden);

            var pdb = new Pkcs5S2ParametersGenerator(new Org.BouncyCastle.Crypto.Digests.Sha256Digest());
            pdb.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()), saltBytes,
                         iterations);
            var key = (KeyParameter)pdb.GenerateDerivedMacParameters(keyLength * 8);
            return Convert.ToBase64String(key.GetKey());
        }


        /// <summary>
        /// Encrypts the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// key
        /// or
        /// Message Required! - message
        /// </exception>
        /// PushBullet requires the encryption to be in the format of [version + tag + IV + encrypted message]
        public static string EncryptMessage(string message, string key)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] versionBytes = Encoding.UTF8.GetBytes("1");

            if (keyBytes == null || keyBytes.Length != KeyBitSize / 8)
                throw new ArgumentException(string.Format("Key needs to be {0} bit!", KeyBitSize), "key");

            if (message == null || message.Length == 0)
                throw new ArgumentException("Message required!", "message");

            //Using random nonce large enough not to repeat
            var nonce = new byte[NonceBitSize / 8];
            Random.NextBytes(nonce, 0, nonce.Length);

            var cipher = new GcmBlockCipher(new AesFastEngine());
            var parameters = new AeadParameters(new KeyParameter(keyBytes), TagBitSize, nonce);
            cipher.Init(true, parameters);

            //Generate Cipher Text With Auth Tag
            var outputSize = cipher.GetOutputSize(messageBytes.Length);
            var cipherText = new byte[outputSize];
            var len = cipher.ProcessBytes(messageBytes, 0, messageBytes.Length, cipherText, 0);
            cipher.DoFinal(cipherText, len);

            //Get the tag and remove the tag from the cipherText
            var tag = cipher.GetMac();
            byte[] encrypted = new byte[cipherText.Length - tag.Length];
            Array.Copy(cipherText, 0, encrypted, 0, encrypted.Length);

            //Assemble Message
            using (var combinedStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(combinedStream))
                {
                    //Prepend the version
                    binaryWriter.Write(versionBytes);
                    //Prepend Tag
                    binaryWriter.Write(tag);
                    //Prepend Nonce
                    binaryWriter.Write(nonce);
                    //Write Encrypted Message
                    binaryWriter.Write(encrypted);
                }
                return Convert.ToBase64String(combinedStream.ToArray());
            }
        }


        /// <summary>
        /// Decrypts the message.
        /// </summary>
        /// <param name="encryptedMessage">The encrypted message.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// key
        /// or
        /// Encrypted Message Required! - encryptedMessage
        /// </exception>
        /// <exception cref="System.Exception">Invalid version!</exception>
        public static string DecryptMessage(string encryptedMessage, string key)
        {
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);
            byte[] keyBytes = Convert.FromBase64String(key);

            if (keyBytes == null || keyBytes.Length != KeyBitSize / 8)
                throw new ArgumentException(string.Format("Key needs to be {0} bit!", KeyBitSize), "key");

            if (encryptedMessage == null || encryptedMessage.Length == 0)
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");

            using (var cipherStream = new MemoryStream(encryptedMessageBytes))
            {
                using (var cipherReader = new BinaryReader(cipherStream))
                {
                    // Get the Version
                    var version = cipherReader.ReadBytes(1);
                    var versionString = Encoding.UTF8.GetString(version, 0, version.Length);
                    if (versionString != "1")
                    {
                        throw new Exception("Invalid version!");
                    }

                    // Get the tag
                    var tag = cipherReader.ReadBytes(TagBitSize / 8);

                    // Get the Nonce (IV)
                    var nonce = cipherReader.ReadBytes(NonceBitSize / 8);

                    var cipher = new GcmBlockCipher(new AesFastEngine());
                    var parameters = new AeadParameters(new KeyParameter(keyBytes), TagBitSize, nonce);
                    cipher.Init(false, parameters);

                    //Decrypt Cipher Text
                    var cipherText = cipherReader.ReadBytes(encryptedMessage.Length - version.Length - nonce.Length);

                    byte[] cipherWithTag = new byte[cipherText.Length + tag.Length];
                    Array.Copy(cipherText, cipherWithTag, cipherText.Length);
                    Array.Copy(tag, 0, cipherWithTag, cipherText.Length, tag.Length);
                    var plainText = new byte[cipher.GetOutputSize(cipherWithTag.Length)];

                    try
                    {
                        var len = cipher.ProcessBytes(cipherWithTag, 0, cipherWithTag.Length, plainText, 0);
                        cipher.DoFinal(plainText, len);

                    }
                    catch (InvalidCipherTextException)
                    {
                        //Return null if it doesn't authenticate
                        return null;
                    }

                    return Encoding.UTF8.GetString(plainText, 0, plainText.Length);
                }
            }
        }

        #endregion Methods
    }
}
