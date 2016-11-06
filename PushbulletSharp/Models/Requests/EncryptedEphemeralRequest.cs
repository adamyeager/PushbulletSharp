using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class EncryptedEphemeralRequest : EphemeralRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedEphemeralRequest"/> class.
        /// </summary>
        public EncryptedEphemeralRequest() : base()
        {
        }

        /// <summary>
        /// Gets or sets the push.
        /// </summary>
        /// <value>
        /// The push.
        /// </value>
        [DataMember(Name = "push")]
        public EncryptedEphemeralMessageRequest Push { get; set; }
    }
}
