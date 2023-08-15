using AutoMapper;
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
    public class CreatePublishedHouseHandler : IRequestHandler<CreatePublishedHouseCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPublishedHouseRepository _publishedHouseRepository;
        public CreatePublishedHouseHandler(IMapper mapper, IPublishedHouseRepository publishedHouseRepository)
        {
            _mapper = mapper;
            _publishedHouseRepository = publishedHouseRepository;
        }
        public async Task<Unit> Handle(CreatePublishedHouseCommand request, CancellationToken cancellationToken)
        {
            var publishedHouse = _mapper.Map<PublishedHouse>(request);
            await _publishedHouseRepository.CreatePublishedHouse(publishedHouse);

            return Unit.Value;
        }
    }
}
