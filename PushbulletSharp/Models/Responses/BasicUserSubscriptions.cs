using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    internal class BasicUserSubscriptions
    {
        public BasicUserSubscriptions()
        {
            this.Subscriptions = new List<BasicSubscription>();
        }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        [DataMember(Name = "subscriptions")]
        public List<BasicSubscription> Subscriptions { get; set; }
    }
}