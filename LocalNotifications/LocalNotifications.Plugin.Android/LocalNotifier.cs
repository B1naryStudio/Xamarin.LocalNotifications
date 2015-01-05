using System;
using System.IO;
using System.Xml.Serialization;
using Android.App;
using Android.Content;
using LocalNotifications.Plugin.Abstractions;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      public void Notify(LocalNotification notification)
      {
          var intent = createIntent(notification.Id);
          
          var serializedNotification = serializeNotification(notification);
          intent.PutExtra(ScheduledAlarmHandler.LocalNotificationKey, serializedNotification);

          var pendingIntent = PendingIntent.GetBroadcast(Application.Context, 0, intent, PendingIntentFlags.CancelCurrent);
          var triggerTime = notifyTimeInMilliseconds(notification.NotifyTime);
          var alarmManager = getAlarmManager();

          alarmManager.Set(AlarmType.RtcWakeup, triggerTime, pendingIntent);
      }

      public void Cancel(int notificationId)
      {
          var intent = createIntent(notificationId);
          var pendingIntent = PendingIntent.GetBroadcast(Application.Context, 0, intent, PendingIntentFlags.CancelCurrent);

          var alarmManager = getAlarmManager();
          alarmManager.Cancel(pendingIntent);

          var notificationManager = getNotificationManager();
          notificationManager.Cancel(notificationId);
      }

      private Intent createIntent(int notificationId)
      {
          return new Intent(Application.Context, typeof (ScheduledAlarmHandler))
              .SetAction("LocalNotifierIntent" + notificationId);
      }

      private NotificationManager getNotificationManager()
      {
          var notificationManager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;
          return notificationManager;
      }

      private AlarmManager getAlarmManager()
      {
          var alarmManager = Application.Context.GetSystemService(Context.AlarmService) as AlarmManager;
          return alarmManager;
      }

      private string serializeNotification(LocalNotification notification)
      {
          var xmlSerializer = new XmlSerializer(notification.GetType());
          using (var stringWriter = new StringWriter())
          {
              xmlSerializer.Serialize(stringWriter, notification);
              return stringWriter.ToString();
          }
      }

      private long notifyTimeInMilliseconds(DateTime notifyTime)
      {
          var utcTime = TimeZoneInfo.ConvertTimeToUtc(notifyTime);
          var epochDifference = (new DateTime(1970, 1, 1) - DateTime.MinValue).TotalSeconds;

          var utcAlarmTimeInMillis = utcTime.AddSeconds(-epochDifference).Ticks / 10000;
          return utcAlarmTimeInMillis;
      }
  }
}