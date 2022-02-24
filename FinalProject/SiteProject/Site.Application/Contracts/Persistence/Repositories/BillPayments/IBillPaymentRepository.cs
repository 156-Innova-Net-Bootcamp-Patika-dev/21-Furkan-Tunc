using Site.Application.Contracts.Persistence.Repositories.Commons;
using Site.Domain.Dtos;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Contracts.Persistence.Repositories.BillPayments
{
    public interface IBillPaymentRepository:IRepositoryBase<BillPayment>
    {
        List<BillDto> GetBillByUserId(int userId);
        BillPayment GetBillByUserIdAndMonth(int userId, int month);
    }
}
