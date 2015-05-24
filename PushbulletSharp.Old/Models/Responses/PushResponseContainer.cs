using System.Collections.Generic;

namespace PushbulletSharp.Old.Models.Responses
{
    public class PushResponseContainer
    {
        public PushResponseContainer()
        {
            pushes = new List<PushResponse>();
        }

        public List<PushResponse> pushes { get; set; }
    }
}