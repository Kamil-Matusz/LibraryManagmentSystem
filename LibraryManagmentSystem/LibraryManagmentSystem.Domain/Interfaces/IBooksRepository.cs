using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Domain.Interfaces;

public interface IBooksRepository
{
    Task CreateBook(Book book);
}