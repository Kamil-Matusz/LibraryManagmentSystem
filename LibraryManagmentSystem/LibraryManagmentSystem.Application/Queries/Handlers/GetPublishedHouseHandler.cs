using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagmentSystem.Application.Queries.Handlers
{
    public class GetPublishedHouseHandler : IRequestHandler<GetPublishedHouseQuery, PublishedHouseDto>
    {
        private readonly IMapper _mapper;
        private readonly IPublishedHouseRepository _publishedHouseRepository;
        public GetPublishedHouseHandler(IMapper mapper, IPublishedHouseRepository publishedHouseRepository)
        {
            _mapper = mapper;
            _publishedHouseRepository = publishedHouseRepository;
        }

        public async Task<PublishedHouseDto> Handle(GetPublishedHouseQuery request, CancellationToken cancellationToken)
        {
            var house = await _publishedHouseRepository.GetPublishedHouse(request.PublishedHouseName);
            var dto = _mapper.Map<PublishedHouseDto>(house);
            return dto;
        }
    }
}
