﻿using FluentValidation;
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
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3)
            .Custom((value, context) =>
            {
                    var existingBook = booksRepository.GetBookByName(value).Result;
                    if (existingBook != null)
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