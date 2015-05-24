using System.Collections.Generic;

namespace PushbulletSharp.Models.Requests
{
    public class PushListRequest : PushRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushListRequest"/> class.
        /// </summary>
        public PushListRequest()
        {
            type = PushbulletConstants.TypeConstants.List;
            items = new List<string>();
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<string> items { get; set; }
    }
}