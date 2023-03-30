using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;
using LibraryManagmentSystem.Infrastructure.DAL;

namespace LibraryManagmentSystem.Infrastructure.Repositories;

internal class BooksRepository : IBooksRepository
{
    private readonly LibraryDbContext _dbContext;

    public BooksRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateBook(Book book)
    {
        _dbContext.Add(book);
        await _dbContext.SaveChangesAsync();
    }
}