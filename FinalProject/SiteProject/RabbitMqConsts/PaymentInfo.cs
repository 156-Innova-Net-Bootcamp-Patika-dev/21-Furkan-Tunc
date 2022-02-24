using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqConsts
{
    public class PaymentInfo : IPaymentInfo
    {
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
        public decimal Pay { get; set; }
    }

    public interface IPaymentInfo
    {
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
        public decimal Pay { get; set; }
    }
}
