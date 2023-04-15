using Dapper;
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

        public ReservationsRepository(LibraryDbContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations() => await _dbContext.Reservations.ToListAsync();

        public async Task<Reservation> GetReservationById(Guid id) => await _dbContext.Reservations.FirstAsync(x => x.ReservationId == id);

        public async Task UpdateReservation() => await _dbContext.SaveChangesAsync();
    }
}
