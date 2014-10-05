using System;
using System.Globalization;

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
    }
}