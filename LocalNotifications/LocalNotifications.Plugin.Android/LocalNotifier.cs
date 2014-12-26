using Android;
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
          var nativeNotification = createNativeNotification(notification);
          var notificationManager = getNotificationManager();
          
          notificationManager.Notify(1, nativeNotification);
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
              .SetSmallIcon(Resource.Drawable.IcDialogEmail);
          
          var nativeNotification = builder.Build();
          return nativeNotification;
      }
  }
}