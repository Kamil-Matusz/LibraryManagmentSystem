using Dapper;
using LibraryManagmentSystem.Domain.Interfaces;
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
            var sql = "SELECT Id,UserName,Email FROM AspNetUsers";
            using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LibraryManagmentSystemDB;Trusted_Connection=True;"))
            {
                connection.Open();
                var result = await connection.QueryAsync<IdentityUser>(sql);
                return result.ToList();
            }
        }
    }
}
