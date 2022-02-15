using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentValidator:AbstractValidator<AddApartmentCommand>
    {
        public AddApartmentValidator()
        {
            RuleFor(a => a.ApartmentNumber).NotEmpty();
            RuleFor(a => a.Blok).NotEmpty();
            RuleFor(a => a.Floor).NotEmpty();
            RuleFor(a => a.Status).NotEmpty();
            RuleFor(a => a.Owner).NotEmpty();
            RuleFor(a => a.Type).NotEmpty();
        }
    }
}
