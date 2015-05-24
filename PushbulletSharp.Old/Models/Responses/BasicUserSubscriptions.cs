using System.Collections.Generic;

namespace PushbulletSharp.Old.Models.Responses
{
    internal class BasicUserSubscriptions
    {
        public BasicUserSubscriptions()
        {
            this.subscriptions = new List<BasicSubscription>();
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public List<BasicSubscription> subscriptions { get; set; }
    }
}