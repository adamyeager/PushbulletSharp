using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [DataContract]
    public abstract class PushNotificationRequestBase : PushBase
    {
        /// <summary>
        /// Gets or sets the notification identifier.
        /// </summary>
        /// <value>
        /// The notification identifier.
        /// </value>
        [DataMember(Name = "notification_id")]
        public string NotificationId { get; set; }

        /// <summary>
        /// Gets or sets the notification tag.
        /// </summary>
        /// <value>
        /// The notification tag.
        /// </value>
        [DataMember(Name = "notification_tag")]
        public string NotificationTag { get; set; }
    }
}