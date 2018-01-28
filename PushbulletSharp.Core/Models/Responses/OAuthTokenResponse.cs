using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class OAuthTokenResponse
    {
        /// <summary>
        /// Gets or sets the token_type.
        /// </summary>
        /// <value>
        /// The token_type.
        /// </value>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// Gets or sets the access_token.
        /// </summary>
        /// <value>
        /// The access_token.
        /// </value>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if(!string.IsNullOrWhiteSpace(AccessToken))
            {
                return AccessToken;
            }

            return base.ToString();
        }
    }
}