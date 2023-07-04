using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class RentalExtendHandler : IRequestHandler<RentalExtendCommand>
    {
        private readonly IReservationsRepository _reservationsRepository;

        public RentalExtendHandler(IReservationsRepository reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
        public async Task<Unit> Handle(RentalExtendCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationsRepository.GetReservationById(request.ReservationId);
            reservation.ReservationEnd = request.ReservationEnd;
            await _reservationsRepository.UpdateReservation();

            return Unit.Value;
        }
    }
}
