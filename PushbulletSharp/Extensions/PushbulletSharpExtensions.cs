using PushbulletSharp.Models.Responses;
using System;
using System.Globalization;
using System.Linq;

namespace PushbulletSharp
{
    public static class PushbulletSharpExtensions
    {
        public static DateTime UnixTimeToDateTime(this string unixTime)
        {
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double seconds = double.Parse(unixTime, CultureInfo.InvariantCulture);
            return epoch.AddSeconds(seconds);
        }

        public static double DateTimeToUnixTime(this DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        /// <summary>
        /// Converts the basic push response.
        /// </summary>
        /// <param name="basicResponse">The basic response.</param>
        /// <returns></returns>
        public static PushResponse ConvertBasicPushResponse(BasicPushResponse basicResponse)
        {
            PushResponse response = new PushResponse();
            response.Active = basicResponse.active;
            response.Created = TimeZoneInfo.ConvertTimeFromUtc(basicResponse.created.UnixTimeToDateTime(), TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            response.Dismissed = basicResponse.dismissed;
            response.Direction = basicResponse.direction;
            response.Iden = basicResponse.iden;
            response.Modified = TimeZoneInfo.ConvertTimeFromUtc(basicResponse.modified.UnixTimeToDateTime(), TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            response.ReceiverEmail = basicResponse.receiver_email;
            response.ReceiverEmailNormalized = basicResponse.receiver_email_normalized;
            response.ReceiverIden = basicResponse.receiver_iden;
            response.SenderEmail = basicResponse.sender_email;
            response.SenderEmailNormalized = basicResponse.sender_email_normalized;
            response.SenderIden = basicResponse.sender_iden;
            response.SenderName = basicResponse.sender_name;
            response.SourceDeviceIden = basicResponse.source_device_iden;
            response.TargetDeviceIden = basicResponse.target_device_iden;
            response.Type = ConvertPushResponseType(basicResponse.type);
            response.ClientIden = basicResponse.client_iden;
            response.Title = basicResponse.title;
            response.Body = basicResponse.body;
            response.Url = basicResponse.url;
            response.FileName = basicResponse.file_name;
            response.FileType = basicResponse.file_type;
            response.FileUrl = basicResponse.file_url;
            response.ImageUrl = basicResponse.image_url;
            response.Name = basicResponse.name;
            response.Address = basicResponse.address;
            if (basicResponse.items != null)
            {
                response.Items = basicResponse.items.Select(o => new ListItem() { Checked = o.Checked, Text = o.text }).ToList();
            }
            return response;
        }


        /// <summary>
        /// Converts the type of the push response.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        private static PushResponseType ConvertPushResponseType(string type)
        {
            switch (type)
            {
                case PushbulletConstants.TypeConstants.Address:
                    return PushResponseType.Address;
                case PushbulletConstants.TypeConstants.File:
                    return PushResponseType.File;
                case PushbulletConstants.TypeConstants.Link:
                    return PushResponseType.Link;
                case PushbulletConstants.TypeConstants.List:
                    return PushResponseType.List;
                case PushbulletConstants.TypeConstants.Note:
                default:
                    return PushResponseType.Note;
            }
        }
    }
}