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
    internal class CreatePublishedHouseValidator : AbstractValidator<CreatePublishedHouseCommand>
    {
        public CreatePublishedHouseValidator(IPublishedHouseRepository publishedHouseRepository)
        {
            RuleFor(x => x.PublishedHouseName)
                .NotEmpty()
                .MinimumLength(3);
        }
    }
}
