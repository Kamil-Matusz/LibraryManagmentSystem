using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Commands.Handlers
{
    public class EditBookHandler : IRequestHandler<EditBookCommand>
    {
        private readonly IBooksRepository _booksRepository;
        public EditBookHandler(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<Unit> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBookByName(request.Name);
            book.Name = request.Name;
            book.Author = request.Author;
            book.Genre = request.Genre;
            book.PublishedDate = request.PublishedDate;

            await _booksRepository.Commit();
            return Unit.Value;
        }
    }
}
