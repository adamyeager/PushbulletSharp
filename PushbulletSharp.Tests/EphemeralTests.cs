using Microsoft.VisualStudio.TestTools.UnitTesting;
using PushbulletSharp.Models.Requests.Ephemerals;
using System;
using System.Linq;

namespace PushbulletSharp.Tests
{
    /// <summary>
    /// These are examples of how to use Ephemerals with PushbulletSharp.
    /// They include both encrypted (strongly recommended) and unencrypted versions of each.
    /// </summary>
    /// <seealso cref="PushbulletSharp.PrivateTests.EncryptionTestBase" />
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
        /// This test is straight out of Pushbullet's documentation. It's just an example of pushing an encrypted Ephemeral.
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
        /// This is an example of sending an encrypted SMS message.
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
        /// This is an example of sending an unencrypted SMS message.
        /// </summary>
        [TestMethod]
        public void UnencryptedSMSTest()
        {
            try
            {
                if (FirstActiveDevice == null)
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
                var result = Client.PushEphemeral(smsRequest);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// This is an example of sending an encrypted Universal Copy Paste Ephemeral.
        /// </summary>
        [TestMethod]
        public void EncryptedUniversalCopyPastTest()
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
        /// This is an example of sending an unencrypted Universal Copy Paste Ephemeral.
        /// </summary>
        [TestMethod]
        public void UnencryptedUniversalCopyPastTest()
        {
            try
            {
                UniversalCopyPasteEphemeral ucpRequest = new UniversalCopyPasteEphemeral()
                {
                    Body = "https://github.com/adamyeager/PushbulletSharp",
                    SourceDeviceIden = FirstActiveDevice.Iden,
                    SourceUserIden = CurrentUser.Iden
                };
                var result = Client.PushEphemeral(ucpRequest);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// This is an example of sending an encrypted notification ephemeral.
        /// </summary>
        [TestMethod]
        public void EncryptedNotificationTest()
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
        /// This is an example of sending an unencrypted notification ephemeral.
        /// </summary>
        [TestMethod]
        public void UnencryptedNotificationTest()
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
                var result = Client.PushEphemeral(notificationRequest);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// This is an example of sending an encrypted dismissal ephemeral.
        /// </summary>
        [TestMethod]
        public void EncryptedDismissalTest()
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


        /// <summary>
        /// This is an example of sending an unencrypted dismissal ephemeral.
        /// </summary>
        [TestMethod]
        public void UnencryptedDismissalTest()
        {
            try
            {
                DismissalEphemeral dismissalRequest = new DismissalEphemeral()
                {
                    NotificationId = "123456789",
                    NotificationTag = null,
                    SourceUserIden = CurrentUser.Iden
                };
                var result = Client.PushEphemeral(dismissalRequest);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}