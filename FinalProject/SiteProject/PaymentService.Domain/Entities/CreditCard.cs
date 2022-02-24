using PaymentService.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Entities
{
    public class CreditCard : EntityBase
    {
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
        public decimal Balance { get; set; }
    }
}
