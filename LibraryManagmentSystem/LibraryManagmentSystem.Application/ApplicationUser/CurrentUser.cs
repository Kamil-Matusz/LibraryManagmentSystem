using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.ApplicationUser
{
    public class CurrentUser
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
        public CurrentUser(string userId,string email, IEnumerable<string> roles)
        {
            UserId = userId;
            Email = email;
            Roles = roles;

        }

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
