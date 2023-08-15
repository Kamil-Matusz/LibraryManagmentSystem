using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Infrastructure.Repositories
{
    internal class PublishedHouseRepository : IPublishedHouseRepository
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public PublishedHouseRepository(LibraryDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task CreatePublishedHouse(PublishedHouse publishedHouse)
        {
            _dbContext.Add(publishedHouse);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PublishedHouse>> GetAllPublishedHouses() => await _dbContext.PublishedHouses.ToListAsync();

        public async Task<PublishedHouse?> GetPublishedHouse(string name) => await _dbContext.PublishedHouses.FirstOrDefaultAsync(x => x.PublishedHouseName.ToLower() == name.ToLower());
    }
}
