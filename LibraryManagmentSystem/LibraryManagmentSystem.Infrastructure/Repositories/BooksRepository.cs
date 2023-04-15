using Dapper;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryManagmentSystem.Infrastructure.Repositories;

internal class BooksRepository : IBooksRepository
{
    private readonly LibraryDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public BooksRepository(LibraryDbContext dbContext,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Task Commit() => _dbContext.SaveChangesAsync();

    public async Task CreateBook(Book book)
    {
        _dbContext.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CreateBookReservation(Reservation reservation)
    {
       _dbContext.Add(reservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteBook(string name)
    {
        using var connection = new SqlConnection(_configuration.GetConnectionString("connectionString"));
        await connection.ExecuteAsync("delete from Books where Name = @bookName", new { bookName = name });
    }

    public async Task<IEnumerable<Book>> GetAllBooks() => await _dbContext.Books.ToListAsync();

    public async Task<Book> GetBook(string name) => await _dbContext.Books.FirstAsync(x => x.Name == name);
   

    public async Task<Book?> GetBookByName(string name) => await _dbContext.Books.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

    public async Task<IEnumerable<Book>> GetBooksByType(string type)
    {
        var books = await _dbContext.Books.FromSqlRaw($"GetBooksByType {type}").ToListAsync();
        return books;
    }

    public Task UpdateBook() => _dbContext.SaveChangesAsync();
}