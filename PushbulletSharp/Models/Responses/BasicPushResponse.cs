namespace PushbulletSharp.Models.Responses
{
    public class BasicPushResponse
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
    }
}