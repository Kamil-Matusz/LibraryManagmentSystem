using Dapper;
using LibraryManagmentSystem.Application.ApplicationUser;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Infrastructure.Repositories
{
    internal class ReservationsRepository : IReservationsRepository
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IUserContext _userContext;

        public ReservationsRepository(LibraryDbContext dbContext,IConfiguration configuration,IUserContext userContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _userContext = userContext;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations() => await _dbContext.Reservations.ToListAsync();

        public async Task<IEnumerable<ReservationWithBookName>> GetAllReservationsWithBookNames()
        {
            var reservationsWithBookName = await _dbContext.Reservations
                .Join
                (_dbContext.Books,
             reservation => reservation.BookId,
             book => book.BookId,
             (reservation, book) => new ReservationWithBookName
             {
                 ReservationId = reservation.ReservationId,
                 BookId = reservation.BookId,
                 ReservationStart = reservation.ReservationStart,
                 ReservationEnd = reservation.ReservationEnd,
                 UserId = reservation.UserId,
                 StatusId = reservation.StatusId,
                 BookName = book.Name
             }).ToListAsync();

            return reservationsWithBookName;
        }

        public async Task<Reservation> GetReservationById(Guid id) => await _dbContext.Reservations.FirstAsync(x => x.ReservationId == id);

        public async Task<IEnumerable<Reservation>> ReservationsInCurrentDay()
        {
            var now = DateTime.Now;
            var day = now.Day;
            var reservations = _dbContext.Reservations.FromSqlRaw($"BookingInCurrentDay {day}");
            await reservations.ToListAsync();

            return reservations;
        }

        public async Task<IEnumerable<Reservation>> ReservationsInCurrentMonth()
        {
            var now = DateTime.Now;
            var month = now.Month;
            var reservations = _dbContext.Reservations.FromSqlRaw($"BookingInCurrentMonth {month}");
            await reservations.ToListAsync();

            return reservations;
        }

        public async Task UpdateReservation() => await _dbContext.SaveChangesAsync();

        public async Task<IEnumerable<Reservation>> UsersReservations()
        {
            var currentUser = _userContext.GetCurrentUser();
            var userId = currentUser.UserId;
            var reservations = await _dbContext.Reservations.Where(x => x.UserId == userId && x.StatusId != 3).ToListAsync();

            return reservations;
        }
    }
}
