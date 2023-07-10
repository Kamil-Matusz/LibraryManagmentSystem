using LibraryManagmentSystem.Application.DTO;
using MediaBrowser.Model.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries
{
    public class GetUserDetailsQuery : IRequest<UserDto>
    {
        public string UserName { get; set; }

        public GetUserDetailsQuery(string userName)
        {
            UserName = userName;
        }
    }
}
