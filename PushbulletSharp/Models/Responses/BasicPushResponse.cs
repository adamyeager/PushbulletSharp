namespace PushbulletSharp.Models.Responses
{
    internal class BasicPushResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool active { get; set; }

        /// <summary>
        /// Gets or sets the iden.
        /// </summary>
        /// <value>
        /// The iden.
        /// </value>
        public string iden { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>
        /// The created.
        /// </value>
        public string created { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        public string modified { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PushResponse"/> is dismissed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if dismissed; otherwise, <c>false</c>.
        /// </value>
        public bool dismissed { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>
        /// The direction.
        /// </value>
        public string direction { get; set; }

        /// <summary>
        /// Gets or sets the sender_iden.
        /// </summary>
        /// <value>
        /// The sender_iden.
        /// </value>
        public string sender_iden { get; set; }

        /// <summary>
        /// Gets or sets the sender_email.
        /// </summary>
        /// <value>
        /// The sender_email.
        /// </value>
        public string sender_email { get; set; }

        /// <summary>
        /// Gets or sets the sender_email_normalized.
        /// </summary>
        /// <value>
        /// The sender_email_normalized.
        /// </value>
        public string sender_email_normalized { get; set; }

        /// <summary>
        /// Gets or sets the sender_name.
        /// </summary>
        /// <value>
        /// The sender_name.
        /// </value>
        public string sender_name { get; set; }

        /// <summary>
        /// Gets or sets the receiver_iden.
        /// </summary>
        /// <value>
        /// The receiver_iden.
        /// </value>
        public string receiver_iden { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email.
        /// </summary>
        /// <value>
        /// The receiver_email.
        /// </value>
        public string receiver_email { get; set; }

        /// <summary>
        /// Gets or sets the receiver_email_normalized.
        /// </summary>
        /// <value>
        /// The receiver_email_normalized.
        /// </value>
        public string receiver_email_normalized { get; set; }

        /// <summary>
        /// Gets or sets the target_device_iden.
        /// </summary>
        /// <value>
        /// The target_device_iden.
        /// </value>
        public string target_device_iden { get; set; }

        /// <summary>
        /// Gets or sets the source_device_iden.
        /// </summary>
        /// <value>
        /// The source_device_iden.
        /// </value>
        public string source_device_iden { get; set; }

        /// <summary>
        /// Gets or sets the client_iden.
        /// </summary>
        /// <value>
        /// The client_iden.
        /// </value>
        public string client_iden { get; set; }

        /// <summary>
        /// Gets or sets the channel_iden.
        /// </summary>
        /// <value>
        /// The channel_iden.
        /// </value>
        public string channel_iden { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string title { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string url { get; set; }

        /// <summary>
        /// Gets or sets the file_name.
        /// </summary>
        /// <value>
        /// The file_name.
        /// </value>
        public string file_name { get; set; }

        /// <summary>
        /// Gets or sets the file_type.
        /// </summary>
        /// <value>
        /// The file_type.
        /// </value>
        public string file_type { get; set; }

        /// <summary>
        /// Gets or sets the file_url.
        /// </summary>
        /// <value>
        /// The file_url.
        /// </value>
        public string file_url { get; set; }

        /// <summary>
        /// Gets or sets the image_url.
        /// </summary>
        /// <value>
        /// The image_url.
        /// </value>
        public string image_url { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string address { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public Item[] items { get; set; }
    }

    internal class Item
    {
        public bool Checked { get; set; }
        public string text { get; set; }
    }
}