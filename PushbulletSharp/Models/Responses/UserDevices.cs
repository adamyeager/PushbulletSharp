using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    public class UserDevices
    {
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