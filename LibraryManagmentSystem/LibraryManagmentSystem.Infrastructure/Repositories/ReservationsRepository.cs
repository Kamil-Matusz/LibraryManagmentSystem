using Dapper;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public ReservationsRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations() => await _dbContext.Reservations.ToListAsync();

        public async Task<Reservation> GetReservationById(Guid id) => await _dbContext.Reservations.FirstAsync(x => x.ReservationId == id);

        public async Task UpdateReservation() => await _dbContext.SaveChangesAsync();
    }
}
