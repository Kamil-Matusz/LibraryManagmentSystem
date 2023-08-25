using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Domain.Models;

namespace LibraryManagmentSystem.Application.Queries.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var pager = new Pager(request.PageIndex, request.PageSize);
            var books = await _booksRepository.GetAllBooks();
            var paginatedBooks = books.AsQueryable().Paginate(pager);
            var dtos = _mapper.Map<IEnumerable<BookDto>>(paginatedBooks);

            return dtos;
        }
    }
}
