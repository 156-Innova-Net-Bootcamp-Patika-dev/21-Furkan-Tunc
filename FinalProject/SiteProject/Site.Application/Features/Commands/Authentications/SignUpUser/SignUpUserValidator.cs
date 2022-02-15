using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserValidatior : AbstractValidator<SignUpUserCommand>
    {
        public SignUpUserValidatior()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("{Email Address} is required.");
            RuleFor(c => c.Password).NotEmpty().WithMessage("{Password} is required.");
        }
    }
}
