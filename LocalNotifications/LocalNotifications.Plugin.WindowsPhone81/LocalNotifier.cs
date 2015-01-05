using System;
using System.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using LocalNotifications.Plugin.Abstractions;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation of ILocalNotifier for Windows Phone 8.1 and WindowsStore
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      /// <summary>
      /// Notifies the specified notification.
      /// </summary>
      /// <param name="notification">The notification.</param>
      public void Notify(LocalNotification notification)
      {
          var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);

          var tileTitle = tileXml.GetElementsByTagName("text");
          ((XmlElement)tileTitle[0]).InnerText = notification.Title;
          ((XmlElement)tileTitle[1]).InnerText = notification.Text;

          var correctedTime = notification.NotifyTime <= DateTime.Now
              ? DateTime.Now.AddMilliseconds(100)
              : notification.NotifyTime;

          var scheduledTileNotification = new ScheduledTileNotification(tileXml, correctedTime)
          {
              Id = notification.Id.ToString()
          };

          TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(scheduledTileNotification);
      }

      /// <summary>
      /// Cancels the specified notification identifier.
      /// </summary>
      /// <param name="notificationId">The notification identifier.</param>
      public void Cancel(int notificationId)
      {
          var scheduledNotifications = TileUpdateManager.CreateTileUpdaterForApplication().GetScheduledTileNotifications();
          var notification =
              scheduledNotifications.FirstOrDefault(n => n.Id.Equals(notificationId.ToString(), StringComparison.OrdinalIgnoreCase));
          
          if (notification != null)
          {
              TileUpdateManager.CreateTileUpdaterForApplication().RemoveFromSchedule(notification);
          }
      }
  }
}