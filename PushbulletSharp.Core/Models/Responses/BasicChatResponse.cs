using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class BasicChatsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicChatsResponse"/> class.
        /// </summary>
        public BasicChatsResponse()
        {
            Chats = new List<BasicChat>();
        }

        /// <summary>
        /// Gets or sets the chats.
        /// </summary>
        /// <value>
        /// The chats.
        /// </value>
        [DataMember(Name = "chats")]
        public List<BasicChat> Chats { get; set; }

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>
        /// The cursor.
        /// </value>
        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
    }
}