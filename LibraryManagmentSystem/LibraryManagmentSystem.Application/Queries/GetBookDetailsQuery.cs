using LibraryManagmentSystem.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Queries
{
    public class GetBookDetailsQuery :  IRequest<BookDto>
    {
        public string BookName { get; set; }

        public GetBookDetailsQuery(string bookName)
        {
            BookName = bookName;
        }
    }
}
