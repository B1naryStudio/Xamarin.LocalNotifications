using LocalNotifications.Plugin.Abstractions;
using System;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Cross platform LocalNotifications implemenations
  /// </summary>
  public class CrossLocalNotifications
  {
    public static ILocalNotifier CreateLocalNotifier()
    {
#if PORTABLE
        return null;
#else
        return new LocalNotifier();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
