using Xunit;
using LibraryManagmentSystem.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.Application.DTO;
using FluentAssertions;
using LibraryManagmentSystem.Domain.Entities;

namespace LibraryManagmentSystem.Application.Mapping.Tests
{
    public class BookMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapBookDtoToBook()
        {
            // arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<BookMappingProfile>());
            var mapper = configuration.CreateMapper();

            var dto = new BookDto
            {
                Name = "Test",
                Author = "TestAuthor",
                Genre = "Fantasy",
                PublishedDate = DateTime.Parse("2023-06-10")
            };

            // act
            var result = mapper.Map<Book>(dto);

            // assert
            result.Should().NotBeNull();
            result.Name.Should().Be(dto.Name);
            result.Author.Should().Be(dto.Author);
            result.Genre.Should().Be(dto.Genre);
            result.PublishedDate.Should().Be(dto.PublishedDate);
        }

        [Fact()]
        public void MappingProfile_ShouldMapBookToBookDto()
        {
            // arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<BookMappingProfile>());
            var mapper = configuration.CreateMapper();

            var book = new Book
            {
                Name = "Test",
                Author = "TestAuthor",
                Genre = "Fantasy",
                PublishedDate = DateTime.Parse("2023-06-10")
            };

            // act
            var result = mapper.Map<BookDto>(book);

            // assert
            result.Should().NotBeNull();
            result.Name.Should().Be(book.Name);
            result.Author.Should().Be(book.Author);
            result.Genre.Should().Be(book.Genre);
            result.PublishedDate.Should().Be(book.PublishedDate);
        }
    }
}