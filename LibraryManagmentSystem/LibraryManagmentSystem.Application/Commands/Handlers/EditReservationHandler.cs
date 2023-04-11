using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class EditReservationHandler : IRequestHandler<EditReservationCommand>
    {
        private readonly IReservationsRepository _reservationsRepository;
        public EditReservationHandler(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
        public async Task<Unit> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationsRepository.GetReservationById(request.ReservationId);

            reservation.ReservationEnd = request.ReservationEnd;
            reservation.StatusId = request.StatusId;

            await _reservationsRepository.UpdateReservation();
            return Unit.Value;
        }
    }
}
