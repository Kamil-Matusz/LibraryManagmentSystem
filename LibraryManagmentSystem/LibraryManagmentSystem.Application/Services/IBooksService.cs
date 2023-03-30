using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Services;

public interface IBooksService
{
    Task CreateBook(Book book);
}