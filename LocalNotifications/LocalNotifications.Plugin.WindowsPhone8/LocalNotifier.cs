using System.Linq;
using LocalNotifications.Plugin.Abstractions;
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
      }

      private FlipTileData createFlipTile(LocalNotification notification)
      {
          var tile = new FlipTileData();

          tile.BackTitle = notification.Title;
          tile.BackContent = notification.Text;
          tile.WideBackContent = notification.Text;

          return tile;
      }
  }
}