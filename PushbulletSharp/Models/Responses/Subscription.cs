using System;
using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class Subscription
    {
        /// <summary>
        /// Gets or sets the iden.
        /// </summary>
        /// <value>
        /// The iden.
        /// </value>
        [DataMember(Name = "iden")]
        public string Iden { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        [DataMember(Name = "modified")]
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Subscription"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        /// <value>
        /// The channel.
        /// </value>
        [DataMember(Name = "channel")]
        public Channel Channel { get; set; }
    }
}