using AutoMapper;
using LibraryManagmentSystem.Application.ApplicationUser;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class CreateReservationHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateReservationHandler(IBooksRepository booksRepository, IMapper mapper, IUserContext userContext)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _mapper.Map<Reservation>(request);

            var currentUser = _userContext.GetCurrentUser();
            if (currentUser is null || currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }

            var book = await _booksRepository.GetBookById(request.BookId);
            if (book.Count <= 0)
            {
                return Unit.Value;
            }

            book.Count--;
            await _booksRepository.UpdateBook();

            reservation.UserId = currentUser.UserId;
            reservation.StatusId = 1;
            await _booksRepository.CreateBookReservation(reservation);

            return Unit.Value;
        }
    }
}
