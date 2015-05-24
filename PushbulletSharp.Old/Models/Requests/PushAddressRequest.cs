namespace PushbulletSharp.Old.Models.Requests
{
    public class PushAddressRequest : PushRequestBase
    {
        public PushAddressRequest()
        {
            type = PushbulletConstants.TypeConstants.Address;
        }

        public string name { get; set; }

        public string address { get; set; }
    }
}