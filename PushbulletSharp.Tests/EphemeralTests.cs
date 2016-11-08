using Microsoft.VisualStudio.TestTools.UnitTesting;
using PushbulletSharp.Models.Requests.Ephemerals;
using System;
using System.Linq;

namespace PushbulletSharp.Tests
{
    [TestClass]
    public class EphemeralTests : EncryptionTestBase
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        private Models.Responses.User CurrentUser { get; set; }

        /// <summary>
        /// Gets or sets the first active device.
        /// </summary>
        /// <value>
        /// The first active device.
        /// </value>
        private Models.Responses.Device FirstActiveDevice { get; set; }

        /// <summary>
        /// Sets the user information up for tests.
        /// </summary>
        [TestInitialize]
        public void SetUserInformationUpForTests()
        {
            CurrentUser = Client.CurrentUsersInformation();
            var userDevices = Client.CurrentUsersDevices(true);
            if (userDevices != null)
            {
                FirstActiveDevice = userDevices.Devices.Where(o => o.HasSMS).FirstOrDefault();
            }
        }

        /// <summary>
        /// Encrypteds the ephemeral test.
        /// </summary>
        [TestMethod]
        public void EncryptedEphemeralTest()
        {
            try
            {
                var result = Client.PushEphemeral("{\"cat\":\"meow\"}", true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Encrypteds the SMS test.
        /// </summary>
        [TestMethod]
        public void EncryptedSMSTest()
        {
            try
            {
                if(FirstActiveDevice == null)
                {
                    Assert.Fail("Could not find a device that has SMS. The user must have a device in their devices list that can relay the ephemeral via SMS.");
                }

                // TargetDeviceIden is the device that you wish to send the SMS text message from.
                // If the user has two devices that can send txt messages, you will need to choose which device you would like to send your message from.
                // This unit test just grabs the first device that HasSMS is set to true.

                SMSEphemeral smsRequest = new SMSEphemeral()
                {
                    ConversationIden = "+1 999 555 1234 --PUT YOUR PHONE NUMBER HERE--",
                    Message = "Hello from PBSharp!",
                    SourceUserIden = CurrentUser.Iden,
                    TargetDeviceIden = FirstActiveDevice.Iden
                };
                var result = Client.PushEphemeral(smsRequest, true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Universals the copy past test.
        /// </summary>
        [TestMethod]
        public void UniversalCopyPastTest()
        {
            try
            {
                UniversalCopyPasteEphemeral ucpRequest = new UniversalCopyPasteEphemeral()
                {
                    Body = "https://github.com/adamyeager/PushbulletSharp",
                    SourceDeviceIden = FirstActiveDevice.Iden,
                    SourceUserIden = CurrentUser.Iden
                };
                var result = Client.PushEphemeral(ucpRequest, true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Notifications the test.
        /// </summary>
        [TestMethod]
        public void NotificationTest()
        {
            try
            {
                NotificationEphemeral notificationRequest = new NotificationEphemeral()
                {
                    Title = "Notification Test",
                    Body = "This is a notification from PushBulletSharp!",
                    Dismissable = true,
                    HasRoot = false,
                    NotificationId = "123456789",
                    NotificationTag = null,
                    SourceDeviceIden = FirstActiveDevice.Iden,
                    SourceUserIden = CurrentUser.Iden
                };
                var result = Client.PushEphemeral(notificationRequest, true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Dismissals the test.
        /// </summary>
        [TestMethod]
        public void DismissalTest()
        {
            try
            {
                DismissalEphemeral dismissalRequest = new DismissalEphemeral()
                {
                    NotificationId = "123456789",
                    NotificationTag = null,
                    SourceUserIden = CurrentUser.Iden
                };
                var result = Client.PushEphemeral(dismissalRequest, true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}