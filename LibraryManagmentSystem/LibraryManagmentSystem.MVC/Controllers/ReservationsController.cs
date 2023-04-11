using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.MVC.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReservationsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());
            return View(reservations);
        }

        [Route("Reservations/{reservationId}/Details")]
        public async Task<IActionResult> ReservationDetails(Guid reservationId)
        {
            var dto = await _mediator.Send(new GetReservationDetailsQuery(reservationId));
            return View(dto);
        }

        [Route("Reservations/{reservationId}/Edit")]
        public async Task<IActionResult> EditReservationStatus(Guid reservationId)
        {
            var dto = await _mediator.Send(new GetReservationDetailsQuery(reservationId));
            EditReservationCommand command = _mapper.Map<EditReservationCommand>(dto);
            return View(command);
        }

        [HttpPost]
        [Route("Reservations/{reservationId}/Edit")]
        public async Task<IActionResult> EditReservationStatus(Guid reservationId, EditReservationCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
