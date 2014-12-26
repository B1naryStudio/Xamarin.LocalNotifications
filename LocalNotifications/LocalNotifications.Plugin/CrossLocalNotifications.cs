using LocalNotifications.Plugin.Abstractions;
using System;

namespace LocalNotifications.Plugin
{
  /// <summary>
  /// Cross platform LocalNotifications implemenations
  /// </summary>
  public class CrossLocalNotifications
  {
    static Lazy<ILocalNotifications> Implementation = new Lazy<ILocalNotifications>(() => CreateLocalNotifications(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static ILocalNotifications Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static ILocalNotifications CreateLocalNotifications()
    {
#if PORTABLE
        return null;
#else
        return new LocalNotificationsImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
