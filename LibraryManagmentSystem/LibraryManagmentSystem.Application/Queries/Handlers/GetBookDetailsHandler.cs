using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries.Handlers
{
    public class GetBookDetailsHandler : IRequestHandler<GetBookDetailsQuery, BookDto>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        public GetBookDetailsHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBook(request.BookName);
            var dto = _mapper.Map<BookDto>(book);
            return dto;
        }
    }
}
