using System;

namespace LocalNotifications.Plugin.Abstractions
{
  /// <summary>
  /// Interface for LocalNotifier
  /// </summary>
  public interface ILocalNotifier
  {
      /// <summary>
      /// Notifies the specified notification.
      /// </summary>
      /// <param name="notification">The notification.</param>
      void Notify(LocalNotification notification);

      /// <summary>
      /// Cancels the specified notification identifier.
      /// </summary>
      /// <param name="notificationId">The notification identifier.</param>
      void Cancel(int notificationId);
  }
}
