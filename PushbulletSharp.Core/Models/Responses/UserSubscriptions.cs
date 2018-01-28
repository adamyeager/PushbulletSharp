using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class UserSubscriptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSubscriptions"/> class.
        /// </summary>
        public UserSubscriptions()
        {
            this.Subscriptions = new List<Subscription>();
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        [DataMember(Name = "subscriptions")]
        public List<Subscription> Subscriptions { get; set; }
    }
}