using LibraryManagmentSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.DAL;

    public class LibraryDbContext : IdentityDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<PublishedHouse> PublishedHouses { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}