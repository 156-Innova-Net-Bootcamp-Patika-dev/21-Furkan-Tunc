using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Apartments.UpdateApartment
{
    public class UpdateApartmentValidator:AbstractValidator<UpdateApartmentCommand>
    {
        public UpdateApartmentValidator()
        {
            RuleFor(a => a.Id).NotEmpty().GreaterThan(0);
        }
    }
}
