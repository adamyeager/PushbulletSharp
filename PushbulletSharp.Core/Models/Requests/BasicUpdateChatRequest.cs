using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class BasicUpdateChatRequest
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UpdateChatRequest"/> is muted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if muted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "muted")]
        public bool Muted { get; set; }
    }
}