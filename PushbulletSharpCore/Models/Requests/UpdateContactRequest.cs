using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class UpdateContactRequest
    {
        /// <summary>
        /// Gets or sets the contact_iden.
        /// </summary>
        /// <value>
        /// The contact_iden.
        /// </value>
        [DataMember(Name = "contact_iden")]
        public string ContactIden { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}