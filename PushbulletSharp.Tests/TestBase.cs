using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletSharp.Tests
{
    public abstract class TestBase
    {
        public PushbulletClient Client { get; set; }
        public string ApiKey { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            ApiKey = "--YOURKEYGOESHERE--";
            Client = new PushbulletClient(ApiKey);

            //Optional pass in your timezone
            //Client = new PushbulletClient(ApiKey, TimeZoneInfo.Local);

            //Or pass in a specific timezone
            //Client = new PushbulletClient(ApiKey, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
        }
    }
}
