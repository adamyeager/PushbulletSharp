using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PushbulletSharp.Models.Requests;
using System;
using System.Linq;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class PushTests : TestBase
    {
        /// <summary>
        /// Currents the user information test.
        /// </summary>
        [TestMethod]
        public void CurrentUserInfoTest()
        {
            try
            {
                var response = Client.CurrentUsersInformation();
                Assert.IsNotNull(response);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        /// <summary>
        /// Deviceses the test.
        /// </summary>
        [TestMethod]
        public void DevicesTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Actives the devices test.
        /// </summary>
        [TestMethod]
        public void ActiveDevicesTest()
        {
            try
            {
                var devices = Client.CurrentUsersActiveDevices();
                Assert.IsNotNull(devices);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the push note test.
        /// </summary>
        [TestMethod]
        public void PushbulletPushNoteTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);

                var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
                Assert.IsNotNull(device, "Could not find the device specified.");

                PushNoteRequest reqeust = new PushNoteRequest()
                {
                    device_iden = device.iden,
                    title = "hello world",
                    body = "This is a test from my C# wrapper."
                };

                var response = Client.PushNote(reqeust);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Pushbullets the push list test.
        /// </summary>
        [TestMethod]
        public void PushbulletPushListTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);

                var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
                Assert.IsNotNull(device, "Could not find the device specified.");

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
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the push address test.
        /// </summary>
        [TestMethod]
        public void PushbulletPushAddressTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);

                var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
                Assert.IsNotNull(device, "Could not find the device specified.");

                PushAddressRequest reqeust = new PushAddressRequest()
                {
                    device_iden = device.iden,
                    name = "Apple Incorporated",
                    address = "1 Infinite Loop, Cupertino, CA 95014"
                };

                var response = Client.PushAddress(reqeust);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the push link test.
        /// </summary>
        [TestMethod]
        public void PushbulletPushLinkTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);

                var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
                Assert.IsNotNull(device, "Could not find the device specified.");

                PushLinkRequest reqeust = new PushLinkRequest()
                {
                    device_iden = device.iden,
                    title = "Google",
                    url = "http://google.com/",
                    body = "Search the internet."
                };

                var response = Client.PushLink(reqeust);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        /// <summary>
        /// Pushbullets the push file test.
        /// </summary>
        [TestMethod]
        public void PushbulletPushFileTest()
        {
            try
            {
                var devices = Client.CurrentUsersDevices();
                Assert.IsNotNull(devices);

                var device = devices.Devices.Where(o => o.manufacturer == "Apple").FirstOrDefault();
                Assert.IsNotNull(device, "Could not find the device specified.");

                using(var fileStream = new FileStream(@"c:\daftpunk.png", FileMode.Open, FileAccess.Read, FileShare.Read)) {
                    PushFileRequest request = new PushFileRequest()
                    {
                        device_iden = device.iden,
                        file_name = "daftpunk.png",
                        file_type = "image/png",
                        file_stream = fileStream,
                        body = "Work It Harder\r\nMake It Better\r\nDo It Faster"
                    };

                    var response = Client.PushFile(request);
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}