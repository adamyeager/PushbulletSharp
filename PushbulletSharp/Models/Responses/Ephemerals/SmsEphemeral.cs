using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses.Ephemerals
{
    [DataContract]
    public class SMSEphemeral : IEphemeral
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
        /// Gets or sets the source_device_iden.
        /// </summary>
        /// <value>
        /// The source_device_iden.
        /// </value>
        [DataMember(Name = "source_device_iden")]
        public string SourceDeviceIden { get; set; }
    }
}