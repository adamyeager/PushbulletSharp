using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    internal class BasicPushResponseContainer
    {
        /// <summary>
        /// Gets or sets the pushes.
        /// </summary>
        /// <value>
        /// The pushes.
        /// </value>
        public List<BasicPushResponse> pushes { get; set; }
    }
}