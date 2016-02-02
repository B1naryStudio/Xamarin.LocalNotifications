using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LocalNotifications.Plugin;
using LocalNotifications.Plugin.Abstractions;
using Xamarin.Forms;

namespace LocalNotifications.Samples.Forms
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var notifier = CrossLocalNotifications.CreateLocalNotifier();
            notifier.Notify(new LocalNotification()
            {
                Title = "Title",
                Text = "Text",
                Id = 1,
                NotifyTime = DateTime.Now.AddSeconds(10),
            });
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
