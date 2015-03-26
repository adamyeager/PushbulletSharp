namespace PushbulletSharp.Models.Requests
{
    public class OAuthTokenRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenRequest"/> class.
        /// </summary>
        public OAuthTokenRequest()
        {
            grant_type = PushbulletConstants.Defaults.OAuth.DefaultGrantType;
        }

        /// <summary>
        /// Gets or sets the grant_type.
        /// </summary>
        /// <value>
        /// The grant_type.
        /// </value>
        public string grant_type { get; set; }

        /// <summary>
        /// Gets or sets the client_id.
        /// </summary>
        /// <value>
        /// The client_id.
        /// </value>
        public string client_id { get; set; }

        /// <summary>
        /// Gets or sets the client_secret.
        /// </summary>
        /// <value>
        /// The client_secret.
        /// </value>
        public string client_secret { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string code { get; set; }
    }
}