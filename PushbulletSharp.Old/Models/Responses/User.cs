namespace PushbulletSharp.Old.Models.Responses
{
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string iden { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the email normalized.
        /// </summary>
        /// <value>
        /// The email normalized.
        /// </value>
        public string email_normalized { get; set; }

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
        /// Gets or sets the google_id.
        /// </summary>
        /// <value>
        /// The google_id.
        /// </value>
        public string google_id { get; set; }

        /// <summary>
        /// Gets or sets the image_url.
        /// </summary>
        /// <value>
        /// The image_url.
        /// </value>
        public string image_url { get; set; }

        /// <summary>
        /// Gets or sets the google_userinfo.
        /// </summary>
        /// <value>
        /// The google_userinfo.
        /// </value>
        public GoogleUserInfo google_userinfo { get; set; }
    }
}