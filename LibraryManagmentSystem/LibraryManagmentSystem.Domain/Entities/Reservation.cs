namespace LibraryManagmentSystem.Domain.Entities;

public class Reservation
{
    public Guid ReservationId { get; set; }
    public int BookId { get; set; }
    public DateTime ReservationStart { get; set; }
    public DateTime ReservationEnd { get; set; }
    public Guid UserId { get; set; }
    public int StatusId { get; set; }

    public Reservation(Guid reservationId, int bookId, DateTime reservationStart, DateTime reservationEnd, Guid userId, int statusId)
    {
        ReservationId = reservationId;
        BookId = bookId;
        ReservationStart = reservationStart;
        ReservationEnd = reservationEnd;
        UserId = userId;
        StatusId = statusId;
    }
}