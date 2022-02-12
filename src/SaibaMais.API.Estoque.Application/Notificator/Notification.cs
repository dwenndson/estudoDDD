namespace SaibaMais.API.Estoque.Application.Notificator
{
    public class Notification
    {
        public string Message { get; set; }

        public Notification(string message)
        {
            Message = message;
        }
    }
}
