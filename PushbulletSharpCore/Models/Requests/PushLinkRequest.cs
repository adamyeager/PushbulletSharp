using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class PushLinkRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushLinkRequest"/> class.
        /// </summary>
        public PushLinkRequest()
        {
            Type = PushbulletConstants.TypeConstants.Link;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [DataMember(Name = "url")]
        public string Url { get; set; }

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