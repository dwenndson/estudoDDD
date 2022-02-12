namespace SaibaMais.API.Estoque.Application.Interfaces
{
    using SaibaMais.API.Estoque.Application.Notificator;
    using System.Collections.Generic;

    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
