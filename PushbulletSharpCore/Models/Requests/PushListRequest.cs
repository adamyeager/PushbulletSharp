using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests
{
    [DataContract]
    public class PushListRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushListRequest"/> class.
        /// </summary>
        public PushListRequest()
        {
            Type = PushbulletConstants.TypeConstants.List;
            Items = new List<string>();
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
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [DataMember(Name = "items")]
        public List<string> Items { get; set; }
    }
}