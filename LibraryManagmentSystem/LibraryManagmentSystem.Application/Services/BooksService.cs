using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Entities;
using LibraryManagmentSystem.Domain.Interfaces;

namespace LibraryManagmentSystem.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMapper _mapper;

    public BooksService(IBooksRepository booksRepository,IMapper mapper)
    {
        _booksRepository = booksRepository;
        _mapper = mapper;
    }
    public async Task CreateBook(BookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _booksRepository.CreateBook(book);
    }

    public async Task<IEnumerable<BookDto>> GetAllBooks()
    {
        var books = await _booksRepository.GetAllBooks();
        var dtos = _mapper.Map<IEnumerable<BookDto>>(books);

        return dtos;
    }
}