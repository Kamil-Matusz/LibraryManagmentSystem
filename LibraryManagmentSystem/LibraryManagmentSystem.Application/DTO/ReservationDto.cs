using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.DTO
{
    public class ReservationDto
    {
        [DisplayName("Reservation ID")]
        public Guid ReservationId { get; set; }
        [DisplayName("Book ID")]
        public int BookId { get; set; }
        [DisplayName("Since when")]
        public DateTime ReservationStart { get; set; }
        [DisplayName("Until When")]
        public DateTime ReservationEnd { get; set; }
        [DisplayName("User ID")]
        public string UserId { get; set; }
        [DisplayName("Status ID")]
        public int StatusId { get; set; }
    }
}
