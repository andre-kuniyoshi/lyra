
namespace ahk.lyra.Application.Notification
{
    public class Notifier : INotifier
    {
        private readonly IList<NotificationMessage> _notifications;
        public Notifier()
        {
            _notifications = new List<NotificationMessage>();
        }

        public void AddNotification(NotificationMessage notification)
        {
            _notifications.Add(notification);
        }

        public IList<NotificationMessage> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
