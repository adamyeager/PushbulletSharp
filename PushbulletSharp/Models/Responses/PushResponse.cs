using System;
using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    public class PushResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the iden.
        /// </summary>
        /// <value>
        /// The iden.
        /// </value>
        public string Iden { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public PushResponseType Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is dismissed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dismissed; otherwise, <c>false</c>.
        /// </value>
        public bool Dismissed { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public string Direction { get; set; }

        /// <summary>
        /// Gets or sets the sender_iden.
        /// </summary>
        /// <value>
        /// The sender_iden.
        /// </value>
        public string SenderIden { get; set; }

        /// <summary>
        /// Gets or sets the sender_email.
        /// </summary>
        /// <value>
        /// The sender_email.
        /// </value>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Gets or sets the sender_email_normalized.
        /// </summary>
        /// <value>
        /// The sender_email_normalized.
        /// </value>
        public string SenderEmailNormalized { get; set; }

        /// <summary>
        /// Gets or sets the sender_name.
        /// </summary>
        /// <value>
        /// The sender_name.
        /// </value>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the receiver_iden.
        /// </summary>
        /// <value>
        /// The receiver_iden.
        /// </value>
        public string ReceiverIden { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email.
        /// </summary>
        /// <value>
        /// The receiver_email.
        /// </value>
        public string ReceiverEmail { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email_normalized.
        /// </summary>
        /// <value>
        /// The receiver_email_normalized.
        /// </value>
        public string ReceiverEmailNormalized { get; set; }

        /// <summary>
        /// Gets or sets the target_device_iden.
        /// </summary>
        /// <value>
        /// The target_device_iden.
        /// </value>
        public string TargetDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the source_device_iden.
        /// </summary>
        /// <value>
        /// The source_device_iden.
        /// </value>
        public string SourceDeviceIden { get; set; }

        /// <summary>
        /// Gets or sets the client iden.
        /// </summary>
        /// <value>
        /// The client iden.
        /// </value>
        public string ClientIden { get; set; }

        /// <summary>
        /// Gets or sets the channel iden.
        /// </summary>
        /// <value>
        /// The channel iden.
        /// </value>
        public string ChannelIden { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the file URL.
        /// </summary>
        /// <value>
        /// The file URL.
        /// </value>
        public string FileUrl { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<ListItem> Items { get; set; }
    }

    /// <summary>
    /// Push Response Types (Note, Link, Address, List, File, etc)
    /// </summary>
    public enum PushResponseType
    {
        Note,
        Link,
        Address,
        List,
        File
    }
}