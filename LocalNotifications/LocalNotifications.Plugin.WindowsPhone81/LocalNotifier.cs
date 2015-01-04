using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using LocalNotifications.Plugin.Abstractions;
using System;


namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation for LocalNotifications
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      public void Notify(LocalNotification notification)
      {
          var tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text02);

          var tileTitle = tileXml.GetElementsByTagName("text");
          ((XmlElement)tileTitle[0]).InnerText = notification.Title;
          ((XmlElement)tileTitle[1]).InnerText = notification.Text;

          var tileNotification = new TileNotification(tileXml);
          TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
      }

      public void Cancel(int notificationId)
      {
          
      }
  }
}