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
    public class GetDayBookingHandler : IRequestHandler<GetDayBookingQuery, IEnumerable<ReservationDto>>
    {
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IMapper _mapper;

        public GetDayBookingHandler(IReservationsRepository reservationsRepository, IMapper mapper)
        {
            _reservationsRepository = reservationsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReservationDto>> Handle(GetDayBookingQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationsRepository.ReservationsInCurrentDay();
            var dtos = _mapper.Map<IEnumerable<ReservationDto>>(reservations);

            return dtos;
        }
    }
}
