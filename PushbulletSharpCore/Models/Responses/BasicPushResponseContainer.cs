using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses
{
    [DataContract]
    internal class BasicPushResponseContainer
    {
        /// <summary>
        /// Gets or sets the pushes.
        /// </summary>
        /// <value>
        /// The pushes.
        /// </value>
        [DataMember(Name = "pushes")]
        public List<BasicPushResponse> Pushes { get; set; }


        [DataMember(Name = "cursor")]
        public string Cursor { get; set; }
    }
}