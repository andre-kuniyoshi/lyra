
namespace ahk.lyra.Application.Notification
{
    public class NotificationMessage
    {
        public string Field { get; set; }
        public string Message { get; set; }

        public NotificationMessage(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}
