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
    public class GetPublishedHouseQuery : IRequest<PublishedHouseDto>
    {
        public string PublishedHouseName { get; set; }
        public GetPublishedHouseQuery(string name)
        {
            PublishedHouseName = name;
        }
    }
}
