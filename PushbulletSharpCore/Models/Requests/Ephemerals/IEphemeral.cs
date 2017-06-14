using System.Runtime.Serialization;

namespace PushbulletSharpCore.Models.Requests.Ephemerals
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