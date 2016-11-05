using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletSharp.Encryption
{
    public class KeyGenerationUtility
    {
        #region Members
        private string _userIden;
        private string _password;
        #endregion Members


        #region Constructors

        public KeyGenerationUtility(string user_iden, string password)
        {
            if (string.IsNullOrWhiteSpace(user_iden))
            {
                throw new ArgumentNullException("user_iden");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }

            _userIden = user_iden;
            _password = password;
        }

        #endregion Constructors


        #region Methods

        public string GenerateKey()
        {
            int keyLength = 32;
            int iterations = 30000;
            byte[] passBytes = Encoding.UTF8.GetBytes(_password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(_userIden);
            return PBKDF2Sha256GetString(keyLength, passBytes, saltBytes, iterations);
        }

        private string PBKDF2Sha256GetString(int dklen, byte[] password, byte[] salt, int iterationCount)
        {
            return "";
            //using (var hmac = new Cryptography.HMACSHA256(password))
            //{
            //    int hashLength = hmac.HashSize / 8;
            //    if ((hmac.HashSize & 7) != 0)
            //        hashLength++;
            //    int keyLength = dklen / hashLength;
            //    if ((long)dklen > (0xFFFFFFFFL * hashLength) || dklen < 0)
            //        throw new ArgumentOutOfRangeException("dklen");
            //    if (dklen % hashLength != 0)
            //        keyLength++;
            //    byte[] extendedkey = new byte[salt.Length + 4];
            //    Buffer.BlockCopy(salt, 0, extendedkey, 0, salt.Length);
            //    using (var ms = new System.IO.MemoryStream())
            //    {
            //        for (int i = 0; i < keyLength; i++)
            //        {
            //            extendedkey[salt.Length] = (byte)(((i + 1) >> 24) & 0xFF);
            //            extendedkey[salt.Length + 1] = (byte)(((i + 1) >> 16) & 0xFF);
            //            extendedkey[salt.Length + 2] = (byte)(((i + 1) >> 8) & 0xFF);
            //            extendedkey[salt.Length + 3] = (byte)(((i + 1)) & 0xFF);
            //            byte[] u = hmac.ComputeHash(extendedkey);
            //            Array.Clear(extendedkey, salt.Length, 4);
            //            byte[] f = u;
            //            for (int j = 1; j < iterationCount; j++)
            //            {
            //                u = hmac.ComputeHash(u);
            //                for (int k = 0; k < f.Length; k++)
            //                {
            //                    f[k] ^= u[k];
            //                }
            //            }
            //            ms.Write(f, 0, f.Length);
            //            Array.Clear(u, 0, u.Length);
            //            Array.Clear(f, 0, f.Length);
            //        }
            //        byte[] dk = new byte[dklen];
            //        ms.Position = 0;
            //        ms.Read(dk, 0, dklen);
            //        ms.Position = 0;
            //        for (long i = 0; i < ms.Length; i++)
            //        {
            //            ms.WriteByte(0);
            //        }
            //        Array.Clear(extendedkey, 0, extendedkey.Length);
            //        return Convert.ToBase64String(dk);
            //    }
            //}
        }

        #endregion Methods
    }
}
