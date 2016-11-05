using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PushbulletSharp.Tests
{
    public abstract class EncryptionTestBase
    {
        public PushbulletClient Client { get; set; }
        public string ApiKey { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            ApiKey = "--YOURKEYGOESHERE--";
            Client = new PushbulletClient(ApiKey, "--YOUR-ENCRYPTION-PASSWORD--", TimeZoneInfo.Local);

            //Optional pass in your timezone
            //Client = new PushbulletClient(ApiKey, TimeZoneInfo.Local);

            //Or pass in a specific timezone
            //Client = new PushbulletClient(ApiKey, "password", TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        }
    }
}