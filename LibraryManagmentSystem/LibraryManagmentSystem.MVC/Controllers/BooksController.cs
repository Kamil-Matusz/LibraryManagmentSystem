using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Application.Queries;
using LibraryManagmentSystem.Application.Services;
using LibraryManagmentSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagmentSystem.MVC.Controllers;

public class BooksController : Controller
{
    private readonly IMediator _mediator;
    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }


    public async Task<IActionResult> Index()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        return View(books);
    }

    public IActionResult CreateBook()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
}