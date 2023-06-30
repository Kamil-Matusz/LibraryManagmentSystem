using Xunit;
using LibraryManagmentSystem.Application.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Domain.Interfaces;
using Moq;

namespace LibraryManagmentSystem.Application.Commands.Handlers.Tests
{
    public class DeleteBookHandlerTests
    {
        [Fact]
        public async Task Handle_DeletesBook()
        {
            // arrange
            var booksRepositoryMock = new Mock<IBooksRepository>();
            var handler = new DeleteBookHandler(booksRepositoryMock.Object);
            var command = new DeleteBookCommand { Name = "TestBook" };
            CancellationToken cancellationToken = default;

            // act
            await handler.Handle(command, cancellationToken);

            // assert
            booksRepositoryMock.Verify(r => r.DeleteBook(command.Name), Times.Once);
        }
    }
}