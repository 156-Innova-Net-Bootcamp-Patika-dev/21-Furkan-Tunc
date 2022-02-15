using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.AddUser
{
    public class AddUserValidator:AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).Must(Contain).WithMessage("Invalid E-mail");
            RuleFor(u => u.Phone).NotEmpty();
            RuleFor(u => u.TcNo).NotEmpty();
        }

        private bool Contain(string arg)
        {
            return arg.Contains('@');
        }
    }
}
