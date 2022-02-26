using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Models.Payment
{
    public class PaymentModel
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
        public decimal Pay { get; set; }
        public int Month { get; set; }
    }
}
