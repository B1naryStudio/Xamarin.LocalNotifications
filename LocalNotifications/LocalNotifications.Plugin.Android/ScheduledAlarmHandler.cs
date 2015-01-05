using System;
using System.IO;
using System.Xml.Serialization;
using Android;
using Android.App;
using Android.Content;
using LocalNotifications.Plugin.Abstractions;

namespace LocalNotifications.Plugin
{
    public class ScheduledAlarmHandler : BroadcastReceiver
    {
        public const string LocalNotificationKey = "LocalNotification";

        public override void OnReceive(Context context, Intent intent)
        {
            var extra = intent.GetStringExtra(LocalNotificationKey);
            var notification = serializeFromString(extra);

            var nativeNotification = createNativeNotification(notification);
            var manager = getNotificationManager();

            manager.Notify(notification.Id, nativeNotification);
        }

        private NotificationManager getNotificationManager()
        {
            var notificationManager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;
            return notificationManager;
        }

        private Notification createNativeNotification(LocalNotification notification)
        {
            var builder = new Notification.Builder(Application.Context)
                .SetContentTitle(notification.Title)
                .SetContentText(notification.Text)
//                .SetSmallIcon(Resource.Drawable.IcDialogEmail);
                .SetSmallIcon(Application.Context.ApplicationInfo.Icon);

            var nativeNotification = builder.Build();
            return nativeNotification;
        }

        private LocalNotification serializeFromString(string notificationString)
        {
            var xmlSerializer = new XmlSerializer(typeof(LocalNotification));
            using (var stringReader = new StringReader(notificationString))
            {
                var notification = (LocalNotification)xmlSerializer.Deserialize(stringReader);
                return notification;
            }
        }
    }
}