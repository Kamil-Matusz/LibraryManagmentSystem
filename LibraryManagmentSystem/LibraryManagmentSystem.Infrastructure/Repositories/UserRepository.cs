using Dapper;
using LibraryManagmentSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsers()
        {
            var connectionString = _configuration.GetSection("database:connectionString").Value;
            var sql = "SELECT Id, UserName, Email FROM AspNetUsers";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QueryAsync<IdentityUser>(sql);
                return result.ToList();
            }
        }

        public async Task<IdentityUser?> GetUserByName(string username)
        {
            var connectionString = _configuration.GetSection("database:connectionString").Value;
            var sql = $"SELECT Id, UserName, Email, PhoneNumber FROM AspNetUsers WHERE UserName = '{username}'";

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await connection.QuerySingleOrDefaultAsync<IdentityUser>(sql);
                return result;
            }
        }
    }
}
