using Xunit;
using LibraryManagmentSystem.Application.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Domain.Entities;
using Moq;
using LibraryManagmentSystem.Application.ApplicationUser;
using LibraryManagmentSystem.Domain.Interfaces;
using AutoMapper;
using MediatR;
using FluentAssertions;

namespace LibraryManagmentSystem.Application.Commands.Handlers.Tests
{
    public class CreateBookHandlerTests
    {
        private readonly Mock<IBooksRepository> _booksRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IUserContext> _userContextMock;

        public CreateBookHandlerTests()
        {
            _booksRepositoryMock = new Mock<IBooksRepository>();
            _mapperMock = new Mock<IMapper>();
            _userContextMock = new Mock<IUserContext>();
        }

        [Fact]
        public async Task Handler_CreateBook_WhenIsAdmin()
        {
            // arrange
            var handler = new CreateBookHandler(_booksRepositoryMock.Object,_mapperMock.Object,_userContextMock.Object);

            var request = new CreateBookCommand();

            var userContextMock = new Mock<IUserContext>();

            userContextMock.Setup(c => c.GetCurrentUser())
                .Returns(new CurrentUser("1", "test@test.com", new[] { "Admin" }));

            // act
            var result = await handler.Handle(request, CancellationToken.None);

            // assert
            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handler_CreateBook_WhenIsNotAdmin()
        {
            // arrange
            var handler = new CreateBookHandler(_booksRepositoryMock.Object, _mapperMock.Object, _userContextMock.Object);

            var request = new CreateBookCommand();

            var userContextMock = new Mock<IUserContext>();

            userContextMock.Setup(c => c.GetCurrentUser())
                .Returns((CurrentUser?)null);

            // act
            var result = await handler.Handle(request, CancellationToken.None);

            // assert
            result.Should().Be(Unit.Value);
        }

    }
}