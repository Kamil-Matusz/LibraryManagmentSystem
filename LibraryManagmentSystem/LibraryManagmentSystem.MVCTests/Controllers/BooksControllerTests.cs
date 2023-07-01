using Xunit;
using LibraryManagmentSystem.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using LibraryManagmentSystem.Application.DTO;
using MediatR;
using Moq;
using LibraryManagmentSystem.Application.Queries;
using FluentAssertions;
using System.Net;

namespace LibraryManagmentSystem.MVC.Controllers.Tests
{
    public class BooksControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public BooksControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Index_ReturnsViewWithExpectedData_ForExistingBooks()
        {
            // arrange
            var books = new List<BookDto>()
            {
                new BookDto()
                {
                    Name = "Book1",
                    Author = "Author1",
                    Genre = "Genre1",
                    PublishedDate = DateTime.Now,
                },

                 new BookDto()
                {
                    Name = "Book2",
                    Author = "Author2",
                    Genre = "Genre2",
                    PublishedDate = DateTime.Now,
                }
            };

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(books);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act
            var response = await client.GetAsync("Books/Index");

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();

            content.Should().Contain("<h1>List of All Books</h1>")
                .And.Contain("Book1")
                .And.Contain("Book2");
        }

        [Fact]
        public async Task Index_ReturnsEmptyView_WhenBooksNotExist()
        {
            // arrange
            var books = new List<BookDto>();

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<GetAllBooksQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(books);

            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureServices(services => services.AddScoped(_ => mediatorMock.Object)))
                .CreateClient();

            // act
            var response = await client.GetAsync("Books/Index");

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}