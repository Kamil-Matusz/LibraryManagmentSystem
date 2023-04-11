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
    public class GetReservationDetailsHandler : IRequestHandler<GetReservationDetailsQuery, ReservationDto>
    {
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IMapper _mapper;
        public GetReservationDetailsHandler(IReservationsRepository reservationsRepository, IMapper mapper)
        {
            _reservationsRepository = reservationsRepository;
            _mapper = mapper;
        }
        public async Task<ReservationDto> Handle(GetReservationDetailsQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationsRepository.GetReservationById(request.ReservationId);
            var dto = _mapper.Map<ReservationDto>(reservation);
            return dto;
        }
    }
}
