using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class DeleteContactRequest
    {
        /// <summary>
        /// Gets or sets the contact_iden.
        /// </summary>
        /// <value>
        /// The contact_iden.
        /// </value>
        [DataMember(Name = "contact_iden")]
        public string ContactIden { get; set; }
    }
}