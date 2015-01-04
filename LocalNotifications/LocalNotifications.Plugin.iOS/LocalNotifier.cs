using System.Linq;
using LocalNotifications.Plugin.Abstractions;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation for LocalNotifications
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      private const string NotificationKey = "LocalNotificationKey";

      public void Notify(LocalNotification notification)
      {
          var nativeNotification = createNativeNotification(notification);
          
          UIApplication.SharedApplication.ScheduleLocalNotification(nativeNotification);
      }

      public void Cancel(int notificationId)
      {
          var notifications = UIApplication.SharedApplication.ScheduledLocalNotifications;
          var notification = notifications.Where(n => n.UserInfo.ContainsKey(NSObject.FromObject(NotificationKey)))
              .FirstOrDefault(n => n.UserInfo[NotificationKey].Equals(NSObject.FromObject(notificationId)));

          if (notification != null)
          {
              UIApplication.SharedApplication.CancelLocalNotification(notification);
          }
      }

      private UILocalNotification createNativeNotification(LocalNotification notification)
      {
          var nativeNotification = new UILocalNotification
          {
              AlertAction = notification.Title,
              AlertBody = notification.Text,
              FireDate = notification.NotifyTime,
              UserInfo = NSDictionary.FromObjectAndKey(NSObject.FromObject(notification.Id), NSObject.FromObject(NotificationKey))
          };

          return nativeNotification;
      }
  }
}