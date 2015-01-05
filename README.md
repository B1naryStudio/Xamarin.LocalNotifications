Local Notifications Plugin for Xamarin and Windows

Simple cross platform plugin to work with mobile local notifications

### Setup
* Available on NuGet: https://www.nuget.org/packages/Xamarin.Plugin.LocalNotifications/
* Install into your PCL project and Client projects.

**Android specific** You must add this line to application manifest within <application></application> tag:
```
<receiver android:name="localnotifications.plugin.ScheduledAlarmHandler" android:enabled="true"></receiver>
```

**Supports**
* Xamarin.iOS
* Xamarin.iOS (x64 Unified)
* Xamarin.Android
* Windows Phone 8.1 RT
* Windows Store 8.0+

### API Usage

Call **CrossLocalNotifications.CreateLocalNotifier** from any project or PCL to gain access to APIs.

User **LocalNotification** class to parameterize notification.

**Creating Notification**
```
var notification = new LocalNotification
					{
						Text = "Hello from Plugin",
						Title = "Notification Plugin",
						Id = 2,
						NotifyTime = DateTime.Now
					};
```

**Sending notification**
```
var notifier = CrossLocalNotifications.CreateLocalNotifier();
notifier.Notify(notification)
```

#### Contributors
* [sbondini](https://github.com/sbondini)
