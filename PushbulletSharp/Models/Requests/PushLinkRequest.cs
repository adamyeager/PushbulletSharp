namespace PushbulletSharp.Models.Requests
{
    public class PushLinkRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushLinkRequest"/> class.
        /// </summary>
        public PushLinkRequest()
        {
            type = PushbulletConstants.TypeConstants.Link;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string url { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
    }
}