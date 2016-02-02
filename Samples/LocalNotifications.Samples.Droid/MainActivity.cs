using System;
using Android.App;
using Android.Widget;
using Android.OS;
using LocalNotifications.Plugin;
using LocalNotifications.Plugin.Abstractions;

namespace LocalNotifications.Samples.Droid
{
    [Activity(Label = "LocalNotifications.Samples.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate
            {
                var notifier = CrossLocalNotifications.CreateLocalNotifier();
                notifier.Notify(new LocalNotification()
                {
                    Title = "Title",
                    Text = "Text",
                    Id = 1,
                    NotifyTime = DateTime.Now.AddSeconds(10),
                });

                Toast.MakeText(Application.Context, "Notification will be triggered in a 10 seconds", ToastLength.Short).Show();
            };
        }
    }
}

