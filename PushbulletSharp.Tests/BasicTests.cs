using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Script.Serialization;
using PushbulletSharp.Models.Requests;
using PushbulletSharp.Models.Responses;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class BasicTests
    {
        public PushbulletManager Manager { get; set; }
        public string ApiKey { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            ApiKey = "<Your Key Goes Here>";
            Manager = new PushbulletManager(ApiKey);
        }




        [TestMethod]
        public void CurrentUserInfoTest()
        {
            var response = Manager.CurrentUsersInformation();
        }


        [TestMethod]
        public void DevicesTest()
        {
            var devices = Manager.CurrentUsersDevices();
        }


        [TestMethod]
        public void ActiveDevicesTest()
        {
            var devices = Manager.CurrentUsersActiveDevices();
        }


        [TestMethod]
        public void PushbulletPushNoteTest()
        {
            var devices = Manager.CurrentUsersDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple" && o.active).FirstOrDefault();

            if (device != null)
            {
                PushNoteRequest reqeust = new PushNoteRequest()
                {
                    device_iden = device.iden,
                    title = "hello world",
                    body = "This is a test from my C# wrapper."
                };

                var response = Manager.PushNote(reqeust);
            }
        }

        [TestMethod]
        public void PushbulletPushListTest()
        {
            var devices = Manager.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple" && o.active).FirstOrDefault();

            if (device != null)
            {
                PushListRequest reqeust = new PushListRequest()
                {
                    device_iden = device.iden,
                    title = "Shopping List"
                };

                reqeust.items.Add("Milk");
                reqeust.items.Add("Bread");
                reqeust.items.Add("Chicken");

                var response = Manager.PushList(reqeust);
            }
        }


        [TestMethod]
        public void PushbulletPushAddressTest()
        {
            var devices = Manager.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple" && o.active).FirstOrDefault();

            if (device != null)
            {
                PushAddressRequest reqeust = new PushAddressRequest()
                {
                    device_iden = device.iden,
                    name = "Apple Incorporated",
                    address = "1 Infinite Loop, Cupertino, CA 95014"
                };

                var response = Manager.PushAddress(reqeust);
            }
        }


        [TestMethod]
        public void PushbulletPushLinkTest()
        {
            var devices = Manager.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple" && o.active).FirstOrDefault();

            if (device != null)
            {
                PushLinkRequest reqeust = new PushLinkRequest()
                {
                    device_iden = device.iden,
                    title = "Google",
                    url = "http://google.com/",
                    body = "Search the internet."
                };

                var response = Manager.PushLink(reqeust);
            }
        }
    }
}
