using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Application.Services;
using LibraryManagmentSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.MVC.Controllers;

public class BooksController : Controller
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    public IActionResult CreateBook()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBook(BookDto book)
    {
        if (!ModelState.IsValid)
        {
            return View(book);
        }
        await _booksService.CreateBook(book);
        return RedirectToAction(nameof(CreateBook));
    }
}