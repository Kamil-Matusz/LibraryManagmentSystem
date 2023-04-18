CREATE PROCEDURE BookingInCurrentDay @Day int
AS 
SELECT * FROM Reservations
WHERE DAY(ReservationStart) = @Day;