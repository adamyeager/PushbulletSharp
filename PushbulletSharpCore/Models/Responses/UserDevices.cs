using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Responses
{
    [DataContract]
    public class UserDevices
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDevices"/> class.
        /// </summary>
        public UserDevices()
        {
            Devices = new List<Device>();
        }

        /// <summary>
        /// Gets or sets the devices.
        /// </summary>
        /// <value>
        /// The devices.
        /// </value>
        [DataMember(Name = "devices")]
        public List<Device> Devices { get; set; }
    }
}