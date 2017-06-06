using System.Runtime.Serialization;

namespace PushbulletSharp.Models
{
    [KnownType(typeof(Requests.Ephemerals.DismissalEphemeral))]
    [KnownType(typeof(Requests.Ephemerals.NotificationEphemeral))]
    [KnownType(typeof(Requests.Ephemerals.SMSEphemeral))]
    [KnownType(typeof(Requests.Ephemerals.UniversalCopyPasteEphemeral))]
    [KnownType(typeof(Responses.Ephemerals.DismissalEphemeral))]
    [KnownType(typeof(Responses.Ephemerals.NotificationEphemeral))]
    [KnownType(typeof(Responses.Ephemerals.SMSEphemeral))]
    [KnownType(typeof(Responses.Ephemerals.UniversalCopyPasteEphemeral))]
    [KnownType(typeof(Requests.Ephemerals.EncryptedEphemeralMessage))]
    [KnownType(typeof(Responses.WebSocket.WebSocketPushResponse))]
    [DataContract]
    public class IEphemeral
    {
    }
}