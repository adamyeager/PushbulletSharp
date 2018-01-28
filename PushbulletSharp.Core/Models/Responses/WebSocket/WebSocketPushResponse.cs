using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses.WebSocket
{
    [DataContract]
    public class WebSocketPushResponse : IEphemeral
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="WebSocketPushResponse"/> is encrypted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if encrypted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "encrypted")]
        public bool Encrypted { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}