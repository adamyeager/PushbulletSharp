using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses.WebSocket
{
    [DataContract]
    public class GenericPushTypeResponse
    {
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