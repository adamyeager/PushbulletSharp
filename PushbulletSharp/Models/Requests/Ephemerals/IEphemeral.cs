using System.Runtime.Serialization;

namespace PushbulletSharp.Models.Requests.Ephemerals
{
    [KnownType(typeof(DismissalEphemeral))]
    [KnownType(typeof(NotificationEphemeral))]
    [KnownType(typeof(SMSEphemeral))]
    [KnownType(typeof(UniversalCopyPasteEphemeral))]
    [DataContract]
    public class IEphemeral
    {
    }
}