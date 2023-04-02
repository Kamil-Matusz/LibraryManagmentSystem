using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Domain.Interfaces;

public interface IBooksRepository
{
    Task CreateBook(Book book);
    Task<Book?> GetBookByName(string name);
    Task<IEnumerable<Book>> GetAllBooks();
    Task<Book> GetBook(string name);
    Task Commit();
}