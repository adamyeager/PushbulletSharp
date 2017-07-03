using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses
{
    [DataContract]
    public class BasicPushResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "active")]
        public bool Active { get; set; }

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
        public string Created { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        [DataMember(Name = "modified")]
        public string Modified { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is dismissed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dismissed; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "dismissed")]
        public bool Dismissed { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        [DataMember(Name = "direction")]
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the sender_iden.
        /// </summary>
        /// <value>
        /// The sender_iden.
        /// </value>
        [DataMember(Name = "sender_iden")]
        public string SenderIden { get; set; }

        /// <summary>
        /// Gets or sets the sender_email.
        /// </summary>
        /// <value>
        /// The sender_email.
        /// </value>
        [DataMember(Name = "sender_email")]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the sender_email_normalized.
        /// </summary>
        /// <value>
        /// The sender_email_normalized.
        /// </value>
        [DataMember(Name = "sender_email_normalized")]
        public string SenderEmailNormalized { get; set; }

        /// <summary>
        /// Gets or sets the sender_name.
        /// </summary>
        /// <value>
        /// The sender_name.
        /// </value>
        [DataMember(Name = "sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the receiver_iden.
        /// </summary>
        /// <value>
        /// The receiver_iden.
        /// </value>
        [DataMember(Name = "receiver_iden")]
        public string ReceiverIden { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email.
        /// </summary>
        /// <value>
        /// The receiver_email.
        /// </value>
        [DataMember(Name = "receiver_email")]
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email_normalized.
        /// </summary>
        /// <value>
        /// The receiver_email_normalized.
        /// </value>
        [DataMember(Name = "receiver_email_normalized")]
        public string ReceiverEmailNormalized { get; set; }

        /// <summary>
        /// Gets or sets the target_device_iden.
        /// </summary>
        /// <value>
        /// The target_device_iden.
        /// </value>
        [DataMember(Name = "target_device_iden")]
        public string TargetDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the source_device_iden.
        /// </summary>
        /// <value>
        /// The source_device_iden.
        /// </value>
        [DataMember(Name = "source_device_iden")]
        public string SourceDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the client_iden.
        /// </summary>
        /// <value>
        /// The client_iden.
        /// </value>
        [DataMember(Name = "client_iden")]
        public string ClientIden { get; set; }

        /// <summary>
        /// Gets or sets the channel_iden.
        /// </summary>
        /// <value>
        /// The channel_iden.
        /// </value>
        [DataMember(Name = "channel_iden")]
        public string ChannelIden { get; set; }

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
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [DataMember(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>
        /// The file_name.
        /// </value>
        [DataMember(Name = "file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file_type.
        /// </summary>
        /// <value>
        /// The file_type.
        /// </value>
        [DataMember(Name = "file_type")]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        [DataMember(Name = "file_url")]
        public string FileUrl { get; set; }

        /// <summary>
        /// Gets or sets the image_url.
        /// </summary>
        /// <value>
        /// The image_url.
        /// </value>
        [DataMember(Name = "image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember(Name = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [DataMember(Name = "items")]
        public Item[] Items { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BasicPushResponse"/> is encrypted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if encrypted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "encrypted")]
        public bool Encrypted { get; set; }
    }

    [DataContract]
    public class Item
    {
        [DataMember(Name = "checked")]
        public bool Checked { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}