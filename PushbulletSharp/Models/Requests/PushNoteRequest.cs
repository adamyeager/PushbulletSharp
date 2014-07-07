namespace PushbulletSharp.Models.Requests
{
    public class PushNoteRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushNoteRequest"/> class.
        /// </summary>
        public PushNoteRequest()
        {
            type = PushbulletConstants.TypeConstants.Note;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
    }
}