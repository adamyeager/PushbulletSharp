using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class PushNoteRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushNoteRequest"/> class.
        /// </summary>
        public PushNoteRequest()
        {
            Type = PushbulletConstants.TypeConstants.Note;
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
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}