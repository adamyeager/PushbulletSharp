using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletSharp.Old.Models.Responses.WebSocket
{
    public class WebSocketResponse
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }

        /// <summary>
        /// Gets or sets the subtype.
        /// </summary>
        /// <value>
        /// The subtype.
        /// </value>
        public string subtype { get; set; }

        /// <summary>
        /// Gets or sets the push.
        /// </summary>
        /// <value>
        /// The push.
        /// </value>
        public BasicPushResponse push { get; set; }
    }
}
