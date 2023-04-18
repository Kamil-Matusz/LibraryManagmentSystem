CREATE PROCEDURE BookingInCurrentMonth @Month int
AS 
SELECT * FROM Reservations
WHERE MONTH(ReservationStart) = @Month;

