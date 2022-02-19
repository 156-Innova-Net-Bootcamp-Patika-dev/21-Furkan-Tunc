using MediatR;
using Site.Application.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Bills.GetBill
{
    public class GetBillQuery:IRequest<List<BillModel>>
    {
        public GetBillQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
