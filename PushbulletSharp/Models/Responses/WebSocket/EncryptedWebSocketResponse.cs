using PushbulletSharp.Models.Requests.Ephemerals;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses.WebSocket
{
    [DataContract]
    public class EncryptedWebSocketResponse
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the subtype.
        /// </summary>
        /// <value>
        /// The subtype.
        /// </value>
        [DataMember(Name = "subtype")]
        public string Subtype { get; set; }

        [DataMember(Name = "push")]
        public EncryptedEphemeralMessage Push { get; set; }
    }
}