using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Script.Serialization;
using PushbulletSharp.Models.Requests;
using PushbulletSharp.Models.Responses;

namespace PushbulletSharp.PrivateTests
{
    [TestClass]
    public class BasicTests
    {
        public PushbulletClient Client { get; set; }
        public string ApiKey { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            ApiKey = "--YOURKEYGOESHERE--";
            Client = new PushbulletClient(ApiKey);
        }




        [TestMethod]
        public void CurrentUserInfoTest()
        {
            var response = Client.CurrentUsersInformation();
        }


        [TestMethod]
        public void DevicesTest()
        {
            var devices = Client.CurrentUsersDevices();
        }


        [TestMethod]
        public void ActiveDevicesTest()
        {
            var devices = Client.CurrentUsersActiveDevices();
        }


        [TestMethod]
        public void PushbulletPushNoteTest()
        {
            var devices = Client.CurrentUsersDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

            if (device != null)
            {
                PushNoteRequest reqeust = new PushNoteRequest()
                {
                    device_iden = device.iden,
                    title = "hello world",
                    body = "This is a test from my C# wrapper."
                };

                var response = Client.PushNote(reqeust);
            }
        }

        [TestMethod]
        public void PushbulletPushListTest()
        {
            var devices = Client.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

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

                var response = Client.PushList(reqeust);
            }
        }


        [TestMethod]
        public void PushbulletPushAddressTest()
        {
            var devices = Client.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

            if (device != null)
            {
                PushAddressRequest reqeust = new PushAddressRequest()
                {
                    device_iden = device.iden,
                    name = "Apple Incorporated",
                    address = "1 Infinite Loop, Cupertino, CA 95014"
                };

                var response = Client.PushAddress(reqeust);
            }
        }


        [TestMethod]
        public void PushbulletPushLinkTest()
        {
            var devices = Client.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

            if (device != null)
            {
                PushLinkRequest reqeust = new PushLinkRequest()
                {
                    device_iden = device.iden,
                    title = "Google",
                    url = "http://google.com/",
                    body = "Search the internet."
                };

                var response = Client.PushLink(reqeust);
            }
        }


        [TestMethod]
        public void PushbulletPushFileTest()
        {
            var devices = Client.CurrentUsersActiveDevices();

            var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();

            if (device != null)
            {
                PushFileRequest request = new PushFileRequest()
                {
                    device_iden = device.iden,
                    file_name = "daftpunk.png",
                    file_type = "image/png",
                    file_path = @"C:\daftpunk.png",
                    body = "Work It Harder\r\nMake It Better\r\nDo It Faster"
                };

                var response = Client.PushFile(request);
            }
        }
    }
}