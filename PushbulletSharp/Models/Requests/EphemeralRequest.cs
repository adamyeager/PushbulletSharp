using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class EphemeralRequest : EphemeralRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EphemeralRequest"/> class.
        /// </summary>
        public EphemeralRequest() : base()
        {
        }

        /// <summary>
        /// Gets or sets the push.
        /// </summary>
        /// <value>
        /// The push.
        /// </value>
        [DataMember(Name = "push")]
        public EphemeralMessageRequest Push { get; set; }
    }
}