using LibraryManagmentSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Domain.Interfaces
{
    public interface IReservationsRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<IEnumerable<Reservation>> UsersReservations();
        Task<IEnumerable<Reservation>> ReservationsInCurrentMonth();
        Task<IEnumerable<Reservation>> ReservationsInCurrentDay();
        Task<Reservation> GetReservationById(Guid id);
        Task UpdateReservation();
    }
}
