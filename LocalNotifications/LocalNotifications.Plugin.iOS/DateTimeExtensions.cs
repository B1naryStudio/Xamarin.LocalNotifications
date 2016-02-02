using System;
using Foundation;

namespace LocalNotifications.Plugin
{
    public static class DateTimeExtensions
    {
        private static DateTime nsUtcRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc); // last zero is milliseconds

        public static double SecondsSinceNSRefenceDate(this DateTime dt)
        {
            return (dt.ToUniversalTime() - nsUtcRef).TotalSeconds;
        }

        public static NSDate ToNSDate(this DateTime dt)
        {
            return NSDate.FromTimeIntervalSinceReferenceDate(dt.SecondsSinceNSRefenceDate());
        }
    }
}