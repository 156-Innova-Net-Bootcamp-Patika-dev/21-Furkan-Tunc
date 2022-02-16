using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserValidator:AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(u => u.ID).NotEmpty().GreaterThan(0);
        }
    }
}
