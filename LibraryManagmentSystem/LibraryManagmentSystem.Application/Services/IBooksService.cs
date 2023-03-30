using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Services;

public interface IBooksService
{
    Task CreateBook(BookDto book);
}