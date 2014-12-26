using System;
using LocalNotifications.Plugin.Abstractions;
using MonoTouch.UIKit;


namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation for LocalNotifications
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      public void Notify(LocalNotification notification)
      {
          var nativeNotification = createNativeNotification(notification);
          
          UIApplication.SharedApplication.ScheduleLocalNotification(nativeNotification);
      }

      private UILocalNotification createNativeNotification(LocalNotification notification)
      {
          var nativeNotification = new UILocalNotification
          {
              AlertAction = notification.Title,
              AlertBody = notification.Text,
              FireDate = notification.NotifyTime
          };

          return nativeNotification;
      }
  }
}