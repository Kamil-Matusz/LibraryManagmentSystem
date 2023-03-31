using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
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
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBooksRepository booksRepository,IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _booksRepository.CreateBook(book);

            return Unit.Value;
        }
    }
}
