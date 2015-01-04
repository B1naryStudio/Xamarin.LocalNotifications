using System;

namespace LocalNotifications.Plugin.Abstractions
{
  /// <summary>
  /// Interface for LocalNotifications
  /// </summary>
  public interface ILocalNotifier
  {
      void Notify(LocalNotification notification);

      void Cancel(int notificationId);
  }
}
