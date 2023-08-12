using AutoMapper;
using LibraryManagmentSystem.Application.ApplicationUser;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateBookHandler(IBooksRepository booksRepository,IMapper mapper, IUserContext userContext)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            var currentUser = _userContext.GetCurrentUser();
            if(currentUser is null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }

            book.CreatedByUserId = currentUser.UserId;
            await _booksRepository.CreateBook(book);

            return Unit.Value;
        }
    }
}
