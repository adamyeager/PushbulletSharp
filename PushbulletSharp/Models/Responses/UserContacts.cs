using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class UserContacts
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContacts"/> class.
        /// </summary>
        public UserContacts()
        {
            Contacts = new List<Contact>();
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        [DataMember(Name = "contacts")]
        public List<Contact> Contacts { get; set; }
    }
}