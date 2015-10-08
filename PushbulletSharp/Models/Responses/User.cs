using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "iden")]
        public string Iden { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the email normalized.
        /// </summary>
        /// <value>
        /// The email normalized.
        /// </value>
        [DataMember(Name = "email_normalized")]
        public string EmailNormalized { get; set; }

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
        /// Gets or sets the google_id.
        /// </summary>
        /// <value>
        /// The google_id.
        /// </value>
        [DataMember(Name = "google_id")]
        public string GoogleId { get; set; }

        /// <summary>
        /// Gets or sets the image_url.
        /// </summary>
        /// <value>
        /// The image_url.
        /// </value>
        [DataMember(Name = "image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the google_userinfo.
        /// </summary>
        /// <value>
        /// The google_userinfo.
        /// </value>
        [DataMember(Name = "google_userinfo")]
        public GoogleUserInfo GoogleUserInfo { get; set; }

        /// <summary>
        /// Gets or sets the preferences.
        /// </summary>
        /// <value>
        /// The preferences.
        /// </value>
        [DataMember(Name = "preferences")]
        public UserPreferences Preferences { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the upload.
        /// </summary>
        /// <value>
        /// The maximum size of the upload.
        /// </value>
        [DataMember(Name = "max_upload_size")]
        public int MaxUploadSize { get; set; }
    }
}