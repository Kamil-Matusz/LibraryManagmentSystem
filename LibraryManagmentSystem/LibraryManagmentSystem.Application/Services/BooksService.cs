using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;

namespace LibraryManagmentSystem.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }
    public async Task CreateBook(Book book)
    {
        await _booksRepository.CreateBook(book);
    }
}