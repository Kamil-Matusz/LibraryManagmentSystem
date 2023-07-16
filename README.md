# LibraryManagmentSystem
A system for managing the library, with the possibility of borrowing books and managing the entire library

# Stack & Technologies
- C# 11
- .NET 6.0
- .NET MVC
- EF Core
- Dapper
- Microsft SQL Server
- Mapper
- iTextSharp

## Database configuration
For the database to work properly, create a migration and apply the appropriate data in the file <b>appsettings.json</b> on line 10 <b>"connectionString"</b> change the database path to your database path.
After changing and starting the project, a database should be created automatically with the initial data.
After creating the database, you need to apply the procedures from the SQL folder.

## Admin
- Book Managment
- Booking Managment
- Generating documents and summaries
- Displaying informations about users accounts
- View book rentals with filters

## User
- Borrowing of books
- Viewing your bookings
- Managing your account

# App Documentation
![](/git_images/BookList.PNG)
![](/git_images/BooksAdminPanel.PNG)
![](/git_images/CreateReservation.PNG)
![](/git_images/LoginPanel.PNG)
![](/git_images/AccountSettings.PNG)
![](/git_images/ExtendRental.PNG)
![](/git_images/ReservationList.PNG)
![](/git_images/UsersList.PNG)
![](/git_images/YoursReservations.PNG)
