using ahk.lyra.Application.Notification;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ahk.lyra.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        protected readonly IMapper Mapper;
        private readonly INotifier _notifier;
        protected MainController(IMapper mapper, INotifier notifier)
        {
            Mapper = mapper;
            _notifier = notifier;
        }

        protected bool HasError()
        {
            return _notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (!HasError())
            {
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Errors = _notifier.GetNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomBadRequestResponse(ModelStateDictionary modelState)
        {
            var errorsInModelState = modelState
                .Where(x => x.Value!.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage)).ToArray();

            var errors = new List<dynamic>();

            foreach (var error in errorsInModelState)
            {
                foreach (var subError in error.Value)
                {
                    var errorModel = new
                    {
                        FieldName = error.Key,
                        Message = subError
                    };

                    errors.Add(errorModel);
                }
            }

            var responseObj = new
            {
                Sucesso = false,
                Erros = errors
            };

            return BadRequest(responseObj);
        }
    }
}
