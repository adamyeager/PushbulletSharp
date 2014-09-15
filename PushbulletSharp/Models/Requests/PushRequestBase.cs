namespace PushbulletSharp.Models.Requests
{
    public abstract class PushRequestBase
    {
        /// <summary>
        /// Gets or sets the device iden.
        /// </summary>
        /// <value>
        /// The device iden.
        /// </value>
        public string device_iden { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string type { get; protected set; }
    }
}