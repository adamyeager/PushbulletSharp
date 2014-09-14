using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
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
        public List<Device> Devices { get; set; }
    }
}