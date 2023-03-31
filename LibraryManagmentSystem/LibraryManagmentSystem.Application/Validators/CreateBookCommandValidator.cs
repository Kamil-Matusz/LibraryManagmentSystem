using FluentValidation;
using LibraryManagmentSystem.Application.DTO;
using LibraryManagmentSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Application.Commands;

namespace LibraryManagmentSystem.Application.Validators
{
    internal class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator(IBooksRepository booksRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
                .Custom((value,context) =>
                {
                    var existingBook = booksRepository.GetBookByName(value).Result;
                    if(existingBook != null)
                    {
                        context.AddFailure($"{value} is not unique for book");
                    }
                });
            RuleFor(x => x.Author)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.Genre)
                .NotEmpty();
            RuleFor(x => x.PublishedDate)
               .NotEmpty();
        }
    }
}
