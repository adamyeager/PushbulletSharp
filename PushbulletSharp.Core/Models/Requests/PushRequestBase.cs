using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public abstract class PushRequestBase
    {
        /// <summary>
        /// Gets or sets the device iden.
        /// </summary>
        /// <value>
        /// The device iden.
        /// </value>
        [DataMember(Name = "device_iden")]
        public string DeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public string Type { get; protected set; }

        /// <summary>
        /// Gets or sets the source_device_iden.
        /// </summary>
        /// <value>
        /// The source_device_iden.
        /// </value>
        [DataMember(Name = "source_device_iden")]
        public string SourceDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the client_iden
        /// </summary>
        /// <value>
        /// The client_iden.
        /// </value>
        [DataMember(Name = "client_iden")]
        public string ClientIden { get; set; }

        /// <summary>
        /// Gets or sets the channel tag
        /// </summary>
        /// <value>
        /// The channel_tag.
        /// </value>
        [DataMember(Name = "channel_tag")]
        public string ChannelTag { get; set; }
    }
}