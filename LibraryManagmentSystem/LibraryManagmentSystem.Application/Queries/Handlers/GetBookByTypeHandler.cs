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
    public class GetBookByTypeHandler : IRequestHandler<GetBooksByTypeQuery, IEnumerable<BookByTypeDto>>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public GetBookByTypeHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookByTypeDto>> Handle(GetBooksByTypeQuery request, CancellationToken cancellationToken)
        {
            var book = await _booksRepository.GetBooksByType(request.Type);
            var dto = _mapper.Map<IEnumerable<BookByTypeDto>>(book);
            return dto;
        }
    }
}
