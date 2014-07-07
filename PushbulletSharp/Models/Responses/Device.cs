namespace PushbulletSharp.Models.Responses
{
    public class Device
    {
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
        /// Gets or sets the nickname.
        /// </summary>
        /// <value>
        /// The nickname.
        /// </value>
        public string nickname { get; set; }

        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        /// <value>
        /// The modified.
        /// </value>
        public string modified { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Device"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool active { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string model { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Device"/> is pushable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if pushable; otherwise, <c>false</c>.
        /// </value>
        public bool pushable { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        public string manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the push_token.
        /// </summary>
        /// <value>
        /// The push_token.
        /// </value>
        public string push_token { get; set; }

        /// <summary>
        /// Gets or sets the app_version.
        /// </summary>
        /// <value>
        /// The app_version.
        /// </value>
        public int app_version { get; set; }
    }
}