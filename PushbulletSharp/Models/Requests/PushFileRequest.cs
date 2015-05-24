using System.IO;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class PushFileRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushFileRequest"/> class.
        /// </summary>
        public PushFileRequest()
        {
            Type = PushbulletConstants.TypeConstants.File;
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        [DataMember(Name = "file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        [DataMember(Name = "file_type")]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file_stream.
        /// </summary>
        /// <value>
        /// The file_stream.
        /// </value>
        [IgnoreDataMember]
        public Stream FileStream { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        [DataMember(Name = "file_url")]
        public string FileUrl { get; set; }

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