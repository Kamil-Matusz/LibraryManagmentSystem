using AutoMapper;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Application.Queries;
using LibraryManagmentSystem.Infrastructure.DAL;
using LibraryManagmentSystem.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagmentSystem.MVC.Controllers;

public class BooksController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly LibraryDbContext _dbContext;
    public BooksController(IMediator mediator,IMapper mapper, LibraryDbContext dbContext)
    {
        _mediator = mediator;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _mediator.Send(new GetAllBooksQuery());
        return View(books);
    }

    public async Task<IActionResult> ScienceFictionBooks()
    {
        string type = "SciFi";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    public async Task<IActionResult> ThrillerBooks()
    {
        string type = "Thriller";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    public async Task<IActionResult> LiteraryFictionBooks()
    {
        string type = "LiteraryFiction";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    public async Task<IActionResult> RomanceBooks()
    {
        string type = "Romance";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    public async Task<IActionResult> BiographiesBooks()
    {
        string type = "Biographies";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    public async Task<IActionResult> ActionsBooks()
    {
        string type = "Action_Adventure";
        var dto = await _mediator.Send(new GetBooksByTypeQuery(type));
        return View(dto);
    }

    [Authorize(Roles = "Admin")]
    public IActionResult CreateBook()
    {
        PublishedHousesDropDownList();
        return View();
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);

        this.SetNotification("success", $"Added book: {command.Name}");

        return RedirectToAction(nameof(Index));
    }

    [Route("Books/{bookName}/Details")]
    public async Task<IActionResult> BookDetails(string bookName)
    {
        var dto = await _mediator.Send(new GetBookDetailsQuery(bookName));
        return View(dto);
    }

    [Route("Books/{bookName}/Edit")]
    public async Task<IActionResult> EditBook(string bookName)
    {
        var dto = await _mediator.Send(new GetBookDetailsQuery(bookName));
        EditBookCommand command = _mapper.Map<EditBookCommand>(dto);
        return View(command);
    }

    [HttpPost]
    [Route("Books/{bookName}/Edit")]
    public async Task<IActionResult> EditBook(string bookName,EditBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        
        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin")]
    [Route("Books/{bookName}/Delete")]
    public async Task<IActionResult> DeleteBook(string bookName)
    {
        var dto = await _mediator.Send(new GetBookDetailsQuery(bookName));
        DeleteBookCommand command = _mapper.Map<DeleteBookCommand>(dto);
        return View(command);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("Books/{bookName}/Delete")]
    public async Task<IActionResult> DeleteBook(string bookName, DeleteBookCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }

    [Authorize]
    public IActionResult CreateBookReservation()
    {
        BooksDropDownList();
        return View();
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBookReservation(CreateReservationCommand command)
    {
        if (!ModelState.IsValid)
        {
            return View(command);
        }
        await _mediator.Send(command);

        return RedirectToAction(nameof(Index));
    }

    private void BooksDropDownList()
    {
        List<SelectListItem> books = new SelectList(_dbContext.Books, "BookId", "Name").ToList();
        ViewBag.Books = books;
    }

    private void PublishedHousesDropDownList()
    {
        List<SelectListItem> publishedHouses = new SelectList(_dbContext.PublishedHouses, "PublishedHouseId", "PublishedHouseName").ToList();
        ViewBag.PublishedHouses = publishedHouses;
    }
}