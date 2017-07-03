using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses
{
    [DataContract]
    public class GoogleUserInfo
    {
        /// <summary>
        /// Gets or sets the family_name.
        /// </summary>
        /// <value>
        /// The family_name.
        /// </value>
        [DataMember(Name = "family_name")]
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        /// <value>
        /// The picture.
        /// </value>
        [DataMember(Name = "picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>
        /// The locale.
        /// </value>
        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>
        /// The link.
        /// </value>
        [DataMember(Name = "link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the given_name.
        /// </summary>
        /// <value>
        /// The given_name.
        /// </value>
        [DataMember(Name = "given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleUserInfo"/> is verified_email.
        /// </summary>
        /// <value>
        ///   <c>true</c> if verified_email; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "verified_email")]
        public bool VerifiedEmail { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if(!string.IsNullOrWhiteSpace(Email))
            {
                return Email;
            }

            return base.ToString();
        }
    }
}