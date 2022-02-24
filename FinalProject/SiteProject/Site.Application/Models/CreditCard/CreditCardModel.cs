using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Models.CreditCard
{
    public class CreditCardModel
    {
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
    }
}
