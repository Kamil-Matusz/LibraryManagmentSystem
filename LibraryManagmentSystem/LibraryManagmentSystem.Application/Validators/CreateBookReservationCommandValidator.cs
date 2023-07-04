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
            RuleFor(x => x.ReservationStart).NotEmpty().Must(BeValidReservationStart);
            RuleFor(x => x.ReservationEnd).NotEmpty().GreaterThan(x => x.ReservationStart);
        }

        private bool BeValidReservationStart(DateTime reservationStart)
        {
            return reservationStart.Date >= DateTime.Today;
        }
    }
}
