using System;

namespace LocalNotifications.Plugin.Abstractions
{
    public class LocalNotification
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime NotifyTime { get; set; }
    }
}
