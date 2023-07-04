using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());
            return View(reservations);
        }

        [Authorize]
        public async Task<IActionResult> YoursReservations()
        {
            var reservations = await _mediator.Send(new GetUsersReservationQuery());
            return View(reservations);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BookingInCurrentMonth()
        {
            var reservations = await _mediator.Send(new GetMonthBookingQuery());
            return View(reservations);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BookingInCurrentDay()
        {
            var reservations = await _mediator.Send(new GetDayBookingQuery());
            return View(reservations);
        }

        [Authorize(Roles = "Admin")]
        [Route("Reservations/{reservationId}/Details")]
        public async Task<IActionResult> ReservationDetails(Guid reservationId)
        {
            var dto = await _mediator.Send(new GetReservationDetailsQuery(reservationId));
            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        [Route("Reservations/{reservationId}/Edit")]
        public async Task<IActionResult> EditReservationStatus(Guid reservationId)
        {
            var dto = await _mediator.Send(new GetReservationDetailsQuery(reservationId));
            EditReservationCommand command = _mapper.Map<EditReservationCommand>(dto);
            return View(command);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize]
        [Route("Reservations/{reservationId}/RentalExtend")]
        public async Task<IActionResult> ExtendRental(Guid reservationId)
        {
            var dto = await _mediator.Send(new GetReservationDetailsQuery(reservationId));
            RentalExtendCommand command = _mapper.Map<RentalExtendCommand>(dto);
            return View(command);
        }

        [Authorize]
        [HttpPost]
        [Route("Reservations/{reservationId}/RentalExtend")]
        public async Task<IActionResult> ExtendRental(Guid reservationId, RentalExtendCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(YoursReservations));
        }

    }
}
