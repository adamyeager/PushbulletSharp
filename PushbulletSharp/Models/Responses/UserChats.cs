using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class UserChats
    {
        /// <summary>
        /// Gets or sets the chats.
        /// </summary>
        /// <value>
        /// The chats.
        /// </value>
        [DataMember(Name = "chats")]
        public Chat[] Chats { get; set; }

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