using PaymentService.Application.Contracts.Persistence.Repositories.Commons;
using PaymentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Contracts.Persistence.Repositories.CreditCards
{
    public interface ICreditCardRepository : IRepositoryBase<CreditCard>
    {
    }
}
