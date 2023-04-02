using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.Infrastructure.Repositories;

internal class BooksRepository : IBooksRepository
{
    private readonly LibraryDbContext _dbContext;

    public BooksRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Commit() => _dbContext.SaveChangesAsync();

    public async Task CreateBook(Book book)
    {
        _dbContext.Add(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAllBooks() => await _dbContext.Books.ToListAsync();

    public async Task<Book> GetBook(string name) => await _dbContext.Books.FirstAsync(x => x.Name == name);
   

    public async Task<Book?> GetBookByName(string name) => await _dbContext.Books.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
}