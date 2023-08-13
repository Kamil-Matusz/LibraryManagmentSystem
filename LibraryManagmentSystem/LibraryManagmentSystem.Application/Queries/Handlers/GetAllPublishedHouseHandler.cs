using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagmentSystem.Application.Queries.Handlers
{
    public class GetAllPublishedHouseHandler : IRequestHandler<GetAllPublishedHousesQuery, IEnumerable<PublishedHouseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPublishedHouseRepository _publishedHouseRepository;
        public GetAllPublishedHouseHandler(IMapper mapper, IPublishedHouseRepository publishedHouseRepository)
        {
            _mapper = mapper;
            _publishedHouseRepository = publishedHouseRepository;
        }

        public async Task<IEnumerable<PublishedHouseDto>> Handle(GetAllPublishedHousesQuery request, CancellationToken cancellationToken)
        {
            var houses = await _publishedHouseRepository.GetAllPublishedHouses();
            var dtos = _mapper.Map<IEnumerable<PublishedHouseDto>>(houses);
            return dtos;
        }
    }
}
