using LibraryManagmentSystem.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries
{
    public class GetBooksByTypeQuery : IRequest<IEnumerable<BookByTypeDto>>
    {
        public string Type { get; set; }
        public GetBooksByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
