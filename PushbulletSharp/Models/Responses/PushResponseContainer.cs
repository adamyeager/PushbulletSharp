using System.Collections.Generic;

namespace PushbulletSharp.Models.Responses
{
    public class PushResponseContainer
    {
        public PushResponseContainer()
        {
            Pushes = new List<PushResponse>();
        }

        public List<PushResponse> Pushes { get; set; }
    }
}