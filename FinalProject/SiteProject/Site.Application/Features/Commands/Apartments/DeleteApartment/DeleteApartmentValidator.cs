using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.DeleteApartment
{
    public class DeleteApartmentValidator:AbstractValidator<DeleteApartmentCommand>
    {
        public DeleteApartmentValidator()
        {
            RuleFor(a => a.ID).NotEmpty();
        }
    }
}
