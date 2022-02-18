using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Bills.AddBill
{
    public class AddBillValidator:AbstractValidator<AddBillCommand>
    {
        public AddBillValidator()
        {
            RuleFor(b => b.Month).NotEmpty().GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(b => b.Electric).GreaterThan(0);
            RuleFor(b => b.NaturalGas).GreaterThan(0);
            RuleFor(b => b.Water).GreaterThan(0);
        }
    }
}
