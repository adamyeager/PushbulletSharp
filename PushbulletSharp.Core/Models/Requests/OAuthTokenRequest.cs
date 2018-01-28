using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class OAuthTokenRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthTokenRequest"/> class.
        /// </summary>
        public OAuthTokenRequest()
        {
            GrantType = PushbulletConstants.Defaults.OAuth.DefaultGrantType;
        }

        /// <summary>
        /// Gets or sets the grant_type.
        /// </summary>
        /// <value>
        /// The grant_type.
        /// </value>
        [DataMember(Name = "grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// Gets or sets the client_id.
        /// </summary>
        /// <value>
        /// The client_id.
        /// </value>
        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client_secret.
        /// </summary>
        /// <value>
        /// The client_secret.
        /// </value>
        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [DataMember(Name = "code")]
        public string Code { get; set; }
    }
}