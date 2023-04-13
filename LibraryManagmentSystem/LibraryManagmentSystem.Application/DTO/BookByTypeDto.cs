using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.DTO
{
    public class BookByTypeDto
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? CreatedByUserId { get; set; }
        public IdentityUser? CreatedBy { get; set; }
    }
}
