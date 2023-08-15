using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.Queries;
using LibraryManagmentSystem.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var houses = await _mediator.Send(new GetAllPublishedHousesQuery());
            return View(houses);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CreatePublishedHouse()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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
