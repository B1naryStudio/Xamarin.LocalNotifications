using System;
using LocalNotifications.Plugin;
using LocalNotifications.Plugin.Abstractions;
using UIKit;

namespace LocalNotifications.Samples.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var notifier = CrossLocalNotifications.CreateLocalNotifier();
            notifier.Notify(new LocalNotification()
            {
                Title = "Title",
                Text = "Text",
                Id = 1,
                NotifyTime = DateTime.Now.AddSeconds(10),
            });
        }
    }
}