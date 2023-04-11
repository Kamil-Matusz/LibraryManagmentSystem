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
    public class CreateBookReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateBookReservationCommandValidator()
        {
            RuleFor(x => x.BookId).NotEmpty();
            RuleFor(x => x.ReservationStart).NotEmpty();
            RuleFor(x => x.ReservationEnd).NotEmpty();
        }
    }
}
