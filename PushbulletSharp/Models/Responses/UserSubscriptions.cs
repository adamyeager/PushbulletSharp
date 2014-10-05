using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    public class UserSubscriptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSubscriptions"/> class.
        /// </summary>
        public UserSubscriptions()
        {
            this.subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        public List<Subscription> subscriptions { get; set; }
    }
}