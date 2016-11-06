using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [DataContract]
    public class PushNotificationRequest : PushNotificationRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PushNotificationRequest"/> class.
        /// </summary>
        public PushNotificationRequest()
        {
            ApplicationName = "PushBulletSharp";
            ClientVersion = 3;
            Type = "mirror";
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon. Base 64 encoded icon
        /// </value>
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [DataMember(Name = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the source device iden.
        /// </summary>
        /// <value>
        /// The source device iden.
        /// </value>
        [DataMember(Name = "source_device_iden")]
        public string SourceDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        [DataMember(Name = "application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushNotificationRequest"/> is dismissable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dismissable; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "dismissable")]
        public bool Dismissable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has root.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has root; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "has_root")]
        public bool HasRoot { get; set; }

        [DataMember(Name = "client_version")]
        public int ClientVersion { get; set; }
    }
}