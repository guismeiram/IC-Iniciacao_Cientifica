using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SGuF.Application.Photo.Command.CreatePhoto;
using SGuF.Application.Photo.Command.DeletePhoto;
using SGuF.Application.Photo.Queries.GetPhoto;
using SGuF.Application.Photo.Queries.GetPhotoList;
using SGuF.Domain.Enities;

namespace SGuF.Web.Controllers
{
    public class PhotoController : BaseController
    {
        public PhotoController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await Mediator.Send(new GetPhotoListQuery.Query());
            return await HandleResult(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePhotoDto photo)
        {
            var result = await Mediator.Send(new CreatePhotoCommand.Command { Photo = photo });

            return Ok(result);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Mediator.Send(new DeletePhotoCommand.Command { Id = id });

            if (result == null) return NotFound();

            return await HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetPhoto.Query{ Id = id});
            return await HandleResult(result);
        }

    }
}
