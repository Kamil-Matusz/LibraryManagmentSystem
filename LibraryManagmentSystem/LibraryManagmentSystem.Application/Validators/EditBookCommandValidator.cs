using FluentValidation;
using LibraryManagmentSystem.Application.Commands;
using LibraryManagmentSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Application.Validators
{
    public class EditBookCommandValidator : AbstractValidator<EditBookCommand>
    {
        public EditBookCommandValidator(IBooksRepository booksRepository)
        {
            RuleFor(x => x.Author)
                .NotEmpty()
                .MinimumLength(3);
            RuleFor(x => x.Genre)
                .NotEmpty();
            RuleFor(x => x.PublishedDate)
               .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.Count)
                .NotEmpty();
        }
    }
}
