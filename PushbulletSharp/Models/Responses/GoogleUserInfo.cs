namespace PushbulletSharp.Models.Responses
{
    public class GoogleUserInfo
    {
        /// <summary>
        /// Gets or sets the family_name.
        /// </summary>
        /// <value>
        /// The family_name.
        /// </value>
        public string family_name { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        public string picture { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>
        /// The locale.
        /// </value>
        public string locale { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string gender { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        public string link { get; set; }

        /// <summary>
        /// Gets or sets the given_name.
        /// </summary>
        /// <value>
        /// The given_name.
        /// </value>
        public string given_name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleUserInfo"/> is verified_email.
        /// </summary>
        /// <value>
        ///   <c>true</c> if verified_email; otherwise, <c>false</c>.
        /// </value>
        public bool verified_email { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if(!string.IsNullOrWhiteSpace(email))
            {
                return email;
            }

            return base.ToString();
        }
    }
}