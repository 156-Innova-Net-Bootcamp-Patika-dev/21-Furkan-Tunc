using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Bills.GetBill
{
    public class GetBillValidator:AbstractValidator<GetBillQuery>
    {
        public GetBillValidator()
        {
            RuleFor(b => b.UserId).NotEmpty().GreaterThan(0);
        }
    }
}
