using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses.Ephemerals
{
    [DataContract]
    public class UniversalCopyPasteEphemeral : IEphemeral
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}