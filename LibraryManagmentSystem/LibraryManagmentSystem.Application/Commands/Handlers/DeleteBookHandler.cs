using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBooksRepository _booksRepository;

        public DeleteBookHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _booksRepository.DeleteBook(request.Name);
            return Unit.Value;
        }
    }
}
