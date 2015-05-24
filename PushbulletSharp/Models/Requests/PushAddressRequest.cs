using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests
{
    [DataContract]
    public class PushAddressRequest : PushRequestBase
    {
        public PushAddressRequest()
        {
            Type = PushbulletConstants.TypeConstants.Address;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }
    }
}