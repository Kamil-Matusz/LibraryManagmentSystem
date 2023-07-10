using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Domain.Entities
{
    public class ReservationWithBookAndStatusName
    {
        public Guid ReservationId { get; set; }
        public int BookId { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public string UserId { get; set; }
        public int StatusId { get; set; }
        public string BookName { get; set; }
        public string StatusName { get; set; }
    }
}
