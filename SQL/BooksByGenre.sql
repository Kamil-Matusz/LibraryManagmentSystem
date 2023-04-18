CREATE PROCEDURE [dbo].[GetBooksByType] @Type varchar(100)
AS 
SELECT * FROM Books
WHERE Books.Genre = @Type;
GO