using System.Linq;
using LocalNotifications.Plugin.Abstractions;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Implementation for LocalNotifications
  /// </summary>
  public class LocalNotifier : ILocalNotifier
  {
      public void Notify(LocalNotification notification)
      {
          var appTile = ShellTile.ActiveTiles.First();

          if (appTile == null) return;

          var tile = createFlipTile(notification);
          appTile.Update(tile);
          
          var shellTileSchedule = new ShellTileSchedule(appTile);
          
          shellTileSchedule.StartTime = notification.NotifyTime;
      }

      public void Cancel(int notificationId)
      {
          throw new System.NotImplementedException();
      }

      private FlipTileData createFlipTile(LocalNotification notification)
      {
          var tile = new FlipTileData
          {
              BackTitle = notification.Title,
              BackContent = notification.Text,
              WideBackContent = notification.Text
          };


          return tile;
      }
  }
}