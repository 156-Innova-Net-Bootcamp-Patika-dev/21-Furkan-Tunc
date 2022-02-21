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
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Phone).NotEmpty().Length(11);
            RuleFor(u => u.TcNo).NotEmpty().Length(11);
        }
    }
}
