using Microsoft.Extensions.Options;
using PaymentService.Application.Contracts.Persistence.Repositories.CreditCards;
using PaymentService.Application.Settings;
using PaymentService.Domain.Entities;
using PaymentService.Infrastructure.Contracts.Persistence.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Infrastructure.Contracts.Persistence.Concrete
{
    public class CreditCardRepository : RepositoryBase<CreditCard>,ICreditCardRepository
    {
        public CreditCardRepository(IOptions<MongoSettings> settings):base(settings)
        {
        }
    }
}
