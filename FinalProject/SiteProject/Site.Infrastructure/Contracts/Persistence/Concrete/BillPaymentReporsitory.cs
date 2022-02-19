using Site.Application.Contracts.Persistence.Repositories.BillPayments;
using Site.Domain.Dtos;
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
        private readonly AppDbContext _dbContext;
        public BillPaymentReporsitory(AppDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BillDto>> GetBillByUserId(int userId)
        {
            var result = from u in _dbContext.Users
                         join b in _dbContext.BillPayments
                         on u.ApartmentId equals b.ApartmentId
                         where u.Id == userId
                         select new BillDto { Electric = b.Electric, NaturalGas = b.NaturalGas, Water = b.Water, Dues = b.Dues, Month = b.Month, TotalDept = b.TotalDept };
            return result.ToList();
        }
    }
}
