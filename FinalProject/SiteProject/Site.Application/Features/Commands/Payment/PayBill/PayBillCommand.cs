using MediatR;
using Site.Application.Models.CreditCard;
using Site.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Payment.PayBill
{
    public class PayBillCommand:IRequest<string>
    { 
        public PayBillCommand(CreditCardModel creditCardModel, int month, decimal pay, int userId)
        {
            UserId = userId;
            Pay = pay;
            Month = month;
            CreditCardNumber = creditCardModel.CreditCardNumber;
            ExpireDate = creditCardModel.ExpireDate;
            Cvc = creditCardModel.Cvc;
        }

        public int UserId { get; set; }
        public decimal Pay { get; set; }
        public int Month { get; set; }
        public string CreditCardNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Cvc { get; set; }
    }
}
