using AutoMapper;
using LibraryManagmentSystem.Application.Queries;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return View(users);
        }

        [Route("Users/{username}/Details")]
        public async Task<IActionResult> UserDetails(string username)
        {
            var dto = await _mediator.Send(new GetUserDetailsQuery(username));
            return View(dto);
        }
    }
}
