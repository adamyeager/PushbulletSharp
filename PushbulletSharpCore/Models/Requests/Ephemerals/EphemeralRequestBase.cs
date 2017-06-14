using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests.Ephemerals
{
    [DataContract]
    public abstract class EphemeralRequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EphemeralRequestBase"/> class.
        /// </summary>
        public EphemeralRequestBase()
        {
            Type = "push";
        }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
