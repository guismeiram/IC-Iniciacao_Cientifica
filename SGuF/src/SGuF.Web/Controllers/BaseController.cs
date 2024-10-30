using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGuF.Application.Common.Models;

namespace SGuF.Web.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected async Task<ActionResult> HandleResult<T>(Result<T> result)
        {
            if (result == null)
            {
                _logger.LogWarning("Received null result.");
                return NotFound();
            }

            if (result.IsSuccess)
            {
                if (result.Value != null)
                    return View(result.Value);
                else
                {
                    _logger.LogWarning("Result was successful but value is null.");
                    return NotFound();
                }
            }

            _logger.LogError($"Error occurred: {result.Error}");
            return BadRequest(result.Error);
        }
    }
}
