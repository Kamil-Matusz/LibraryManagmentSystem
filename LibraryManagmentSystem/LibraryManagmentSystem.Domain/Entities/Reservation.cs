namespace LibraryManagmentSystem.Domain.Entities;

public class Reservation
{
    public Guid ReservationId { get; set; }
    public int BookId { get; set; }
    public DateTime ReservationStart { get; set; }
    public DateTime ReservationEnd { get; set; }
    public string UserId { get; set; }
    public int StatusId { get; set; }
    
}