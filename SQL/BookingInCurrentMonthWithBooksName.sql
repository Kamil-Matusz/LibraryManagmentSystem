CREATE PROCEDURE BookingInCurrentMonthWithBooksName
    @Month INT
AS 
BEGIN
    SELECT r.ReservationId,r.BookId,r.ReservationStart,r.ReservationEnd,r.UserId,r.StatusId,b.Name AS BookName
    FROM Reservations AS r
    INNER JOIN Books AS b ON r.BookId = b.BookId
    WHERE MONTH(r.ReservationStart) = @Month;
END;