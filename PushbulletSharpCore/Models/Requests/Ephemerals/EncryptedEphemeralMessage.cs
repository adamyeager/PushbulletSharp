using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests.Ephemerals
{
    [DataContract]
    public class EncryptedEphemeralMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptedEphemeralMessage"/> class.
        /// </summary>
        public EncryptedEphemeralMessage()
        {
            Encrypted = true;
        }

        /// <summary>
        /// Gets or sets the cipher text.
        /// </summary>
        /// <value>
        /// The cipher text.
        /// </value>
        [DataMember(Name = "ciphertext")]
        public string CipherText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EncryptedEphemeralMessage"/> is encrypted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if encrypted; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "encrypted")]
        public bool Encrypted { get; set; }
    }
}