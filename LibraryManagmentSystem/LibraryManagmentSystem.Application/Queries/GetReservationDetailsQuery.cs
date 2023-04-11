using LibraryManagmentSystem.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries
{
    public class GetReservationDetailsQuery : IRequest<ReservationDto>
    {
        public Guid ReservationId { get; set; }
        public GetReservationDetailsQuery(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
