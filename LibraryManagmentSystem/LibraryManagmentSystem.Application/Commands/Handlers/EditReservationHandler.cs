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
        private readonly IBooksRepository _booksRepository;
        public EditReservationHandler(IReservationsRepository reservationsRepository, IBooksRepository booksRepository)
        {
            _reservationsRepository = reservationsRepository;
            _booksRepository = booksRepository;
        }
        public async Task<Unit> Handle(EditReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationsRepository.GetReservationById(request.ReservationId);

            reservation.ReservationEnd = request.ReservationEnd;
            reservation.StatusId = request.StatusId;

            if (reservation.StatusId == 3)
            {
                var book = await _booksRepository.GetBookById(request.BookId);
                book.Count++;
                await _booksRepository.UpdateBook();
            }
            
            await _reservationsRepository.UpdateReservation();
            return Unit.Value;
        }
    }
}
