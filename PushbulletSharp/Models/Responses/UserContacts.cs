using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    public class UserContacts
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContacts"/> class.
        /// </summary>
        public UserContacts()
        {
            contacts = new List<Contact>();
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public List<Contact> contacts { get; set; }
    }
}