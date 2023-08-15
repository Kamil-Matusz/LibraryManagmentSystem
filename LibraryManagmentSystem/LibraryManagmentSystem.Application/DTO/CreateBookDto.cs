using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.DTO
{
    public class CreateBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublishedHouseId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
