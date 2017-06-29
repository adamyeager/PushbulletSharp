using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class DeleteChatRequest
    {
        /// <summary>
        /// Gets or sets the chat iden.
        /// </summary>
        /// <value>
        /// The chat iden.
        /// </value>
        [DataMember(Name = "chat_iden")]
        public string ChatIden { get; set; }
    }
}