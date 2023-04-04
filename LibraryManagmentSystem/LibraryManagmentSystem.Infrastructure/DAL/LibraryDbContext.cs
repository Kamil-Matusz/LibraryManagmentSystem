using LibraryManagmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.DAL;

internal class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Status> Status { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}