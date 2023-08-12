using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.MVC.Controllers
{
    public class PublishedHousesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PublishedHousesController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public IActionResult CreatePublishedHouse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublishedHouse(CreatePublishedHouseCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);

            this.SetNotification("success", $"Added new published house: {command.PublishedHouseName}");

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
