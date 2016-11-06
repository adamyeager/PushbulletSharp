using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [DataContract]
    public class PushDismissalRequest : PushNotificationRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushDismissalRequest"/> class.
        /// </summary>
        public PushDismissalRequest()
        {
            Type = "dismissal";
        }
    }
}