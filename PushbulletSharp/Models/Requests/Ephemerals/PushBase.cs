using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [DataContract]
    public class PushBase : IEphemeral
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
        /// Gets or sets the name of the package.
        /// </summary>
        /// <value>
        /// The name of the package.
        /// </value>
        [DataMember(Name = "package_name")]
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the source user iden.
        /// </summary>
        /// <value>
        /// The source user iden.
        /// </value>
        [DataMember(Name = "source_user_iden")]
        public string SourceUserIden { get; set; }
    }
}