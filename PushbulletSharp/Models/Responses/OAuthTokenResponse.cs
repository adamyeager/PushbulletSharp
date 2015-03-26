namespace PushbulletSharp.Models.Responses
{
    public class OAuthTokenResponse
    {
        /// <summary>
        /// Gets or sets the token_type.
        /// </summary>
        /// <value>
        /// The token_type.
        /// </value>
        public string token_type { get; set; }

        /// <summary>
        /// Gets or sets the access_token.
        /// </summary>
        /// <value>
        /// The access_token.
        /// </value>
        public string access_token { get; set; }
    }
}