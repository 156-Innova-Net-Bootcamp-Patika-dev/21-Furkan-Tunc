using MediatR;
using Site.Application.Models.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Bills.GetAllBills
{
    public class GetAllBillsQuery:IRequest<List<BillModel>>
    {
    }
}
