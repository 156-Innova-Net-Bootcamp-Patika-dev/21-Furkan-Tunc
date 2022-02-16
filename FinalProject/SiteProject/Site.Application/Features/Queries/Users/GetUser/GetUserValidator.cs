using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Users.GetUser
{
    public class GetUserValidator:AbstractValidator<GetUserQuery>
    {
        public GetUserValidator()
        {
            RuleFor(u => u.ID).NotEmpty().GreaterThan(0);
        }
    }
}
