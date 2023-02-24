
namespace ahk.lyra.Application.Notification
{
    public interface INotifier
    {
        bool HasNotification();
        IList<NotificationMessage> GetNotifications();
        void AddNotification(NotificationMessage notification);
    }
}
