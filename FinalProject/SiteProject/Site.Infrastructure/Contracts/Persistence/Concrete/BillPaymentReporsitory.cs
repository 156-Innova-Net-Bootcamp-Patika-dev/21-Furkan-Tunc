using Site.Application.Contracts.Persistence.Repositories.BillPayments;
using Site.Domain.Entities;
using Site.Infrastructure.Contracts.Persistence.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Infrastructure.Contracts.Persistence.Concrete
{
    public class BillPaymentReporsitory:RepositoryBase<BillPayment>,IBillPaymentRepository
    {
        public BillPaymentReporsitory(AppDbContext dbContext):base(dbContext)
        {
        }
    }
}
