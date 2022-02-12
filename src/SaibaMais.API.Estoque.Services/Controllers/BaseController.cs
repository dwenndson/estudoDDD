namespace SaibaMais.API.Estoque.Services.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using SaibaMais.API.Estoque.Application.Interfaces;
    using SaibaMais.API.Estoque.Application.Notificator;

    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotificator _notificator;

        public BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificator.GetNotifications().Select(n => n.Message)
            });
        }

        protected void ValidateModelState(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificateInvalidModelError(modelState);
        }

        protected void NotificateInvalidModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotificateError(errorMsg);
            }
        }

        protected void NotificateError(string message)
        {
            _notificator.Handle(new Notification(message));
        }
    }
}