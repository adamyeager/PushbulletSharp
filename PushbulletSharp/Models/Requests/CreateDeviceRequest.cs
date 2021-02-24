using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class CreateDeviceRequest
    {
        /// <summary>
        /// The device's nickname
        /// </summary>
        /// <remarks>
        /// This is the name that's usualy visible in the UI
        /// </remarks>
        [DataMember(Name = "nickname")]
        public string Nickname { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "manufacturer")]
        public string  Manufacturer { get; set; }

        [DataMember(Name = "app_version")]
        public int AppVersion { get; set; }
    }
}
