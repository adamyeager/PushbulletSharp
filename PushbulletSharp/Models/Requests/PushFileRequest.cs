namespace PushbulletSharp.Models.Requests
{
    public class PushFileRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushFileRequest"/> class.
        /// </summary>
        public PushFileRequest()
        {
            type = PushbulletConstants.TypeConstants.File;
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string file_name { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        public string file_type { get; set; }

        /// <summary>
        /// Gets or sets the file_path.
        /// </summary>
        /// <value>
        /// The file_path.
        /// </value>
        public string file_path { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        public string file_url { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
    }
}