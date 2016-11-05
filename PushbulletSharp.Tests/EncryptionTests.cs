using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class EncryptionTests : EncryptionTestBase
    {
        /// <summary>
        /// Encryptions the test.
        /// </summary>
        [TestMethod]
        public void EncryptionTest()
        {
            try
            {
                // The provided test key is from PushBullet's API doc
                string message = "This is a test from the PushBulletSharp library!";
                string key = "1sW28zp7CWv5TtGjlQpDHHG4Cbr9v36fG5o4f74LsKg=";
                string encryptedMessage = Encryption.EncryptionUtility.EncryptMessage(message, key);

                Assert.IsNotNull(encryptedMessage);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Decryptions the test.
        /// </summary>
        [TestMethod]
        public void DecryptionTest()
        {
            try
            {
                // The provided test message & key are from PushBullet's API doc (it should say "meow!")
                string encryptedMessage = "MSfJxxY5YdjttlfUkCaKA57qU9SuCN8+ZhYg/xieI+lDnQ==";
                string key = "1sW28zp7CWv5TtGjlQpDHHG4Cbr9v36fG5o4f74LsKg=";
                string message = Encryption.EncryptionUtility.DecryptMessage(encryptedMessage, key);

                Assert.IsTrue(message == "meow!");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}