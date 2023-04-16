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
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {
    }
}
