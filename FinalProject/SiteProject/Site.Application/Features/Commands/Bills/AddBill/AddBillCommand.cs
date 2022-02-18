using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Bills.AddBill
{
    public class AddBillCommand:IRequest<int>
    {
        public decimal Electric { get; set; }
        public decimal Water { get; set; }
        public decimal NaturalGas { get; set; }
        public decimal Dues { get; set; }
        public int Month { get; set; }
    }
}
