using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentValidator:AbstractValidator<GetApartmentQuery>
    {
        public GetApartmentValidator()
        {
            RuleFor(a => a.ID).NotNull().GreaterThan(0);
        }
    }
}
