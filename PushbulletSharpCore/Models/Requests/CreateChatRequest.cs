using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class CreateChatRequest
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}