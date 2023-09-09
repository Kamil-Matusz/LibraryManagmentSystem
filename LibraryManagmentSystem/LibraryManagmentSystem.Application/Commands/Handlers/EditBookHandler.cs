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
            var book = await _booksRepository.GetBookByName(request.Name!);
            
            book.Author = request.Author;
            book.PublishedHouseId = request.PublishedHouseId;
            book.PublishedDate = request.PublishedDate;
            book.Description = request.Description;
            book.Count = request.Count;

            await _booksRepository.UpdateBook();
            return Unit.Value;
        }
    }
}
