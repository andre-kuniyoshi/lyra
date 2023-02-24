using ahk.lyra.Application.Notification;

namespace ahk.lyra.Application.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void AddNotification(string field, string message)
        {
            _notifier.AddNotification(new NotificationMessage(field, message));
        }
    }
}
