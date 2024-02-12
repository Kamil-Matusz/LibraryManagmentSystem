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
- FluentValidation
- iTextSharp
- Docker

# Database
![](/git_images/Database.PNG)

## Database configuration
For the database to work properly, create a migration and apply the appropriate data in the file <b>appsettings.json</b> on line 10 <b>"connectionString"</b> change the database path to your database path.
After changing and starting the project, a database should be created automatically with the initial data.
After creating the database, you need to apply the procedures from the SQL folder.

# Docker
This repository includes a Docker Compose configuration for setting up a local development environment for the Library Management System. The configuration consists of two services:
- **SqlServer:** Sets up a Microsoft SQL Server container with necessary environment variables for proper configuration.
- **librarymanagmentsystem.mvc:** Runs a .NET MVC application container, providing the frontend interface for the library management system.

## Docker Configuration
1. Clone this repository to your local machine.
2. Navigate to the root directory of the cloned repository.
3. Modify the `docker-compose.yml` file to adjust any necessary configurations.
4. Open a terminal and run the following command to start the containers: <b>`docker compose up`</b>

## Admin
- Book Managment
- Booking Managment
- Adding new Book Published Houses
- Generating documents and summaries
- Displaying informations about users accounts
- View book rentals with filters
- Change View to dark mode

## User
- Borrowing of books
- Viewing your bookings
- Managing your account
- Change View to dark mode

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
![](/git_images/PublishedHouses.PNG)
![](/git_images/CreatingPublishHouse.PNG)
