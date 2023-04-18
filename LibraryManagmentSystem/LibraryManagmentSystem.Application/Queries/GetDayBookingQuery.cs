using LibraryManagmentSystem.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries
{
    public class GetDayBookingQuery : IRequest<IEnumerable<ReservationDto>>
    {
    }
}
