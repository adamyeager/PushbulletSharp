using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Responses
{
    [DataContract]
    public class UserPreferences
    {
        /// <summary>
        /// Gets or sets the onboarding.
        /// </summary>
        /// <value>
        /// The onboarding.
        /// </value>
        [DataMember(Name = "onboarding")]
        public Onboarding Onboarding { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserPreferences"/> is social.
        /// </summary>
        /// <value>
        ///   <c>true</c> if social; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "social")]
        public bool Social { get; set; }
    }

    [DataContract]
    public class Onboarding
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Onboarding"/> is application.
        /// </summary>
        /// <value>
        ///   <c>true</c> if application; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "app")]
        public bool App { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Onboarding"/> is extension.
        /// </summary>
        /// <value>
        ///   <c>true</c> if extension; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "extension")]
        public bool Extension { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Onboarding"/> is friends.
        /// </summary>
        /// <value>
        ///   <c>true</c> if friends; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "friends")]
        public bool Friends { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [whats new].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [whats new]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "whatsnew")]
        public bool WhatsNew { get; set; }
    }
}