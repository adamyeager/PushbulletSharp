using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [DataContract]
    public class PushSMSRequest : PushBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushSMSRequest"/> class.
        /// </summary>
        public PushSMSRequest()
        {
            Type = "messaging_extension_reply";
            PackageName = "com.pushbullet.android";
        }

        /// <summary>
        /// Gets or sets the target device iden.
        /// </summary>
        /// <value>
        /// The target device iden.
        /// </value>
        [DataMember(Name = "target_device_iden")]
        public string TargetDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the conversation iden.
        /// </summary>
        /// <value>
        /// The conversation iden. For SMS this will be a phonenumber +1 999 555 1234
        /// </value>
        [DataMember(Name = "conversation_iden")]
        public string ConversationIden { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}