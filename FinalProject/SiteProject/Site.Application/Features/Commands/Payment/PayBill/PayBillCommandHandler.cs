using MediatR;
using FluentValidation;
using Site.Application.Contracts.Persistence.Repositories.BillPayments;
using System.Threading;
using System.Threading.Tasks;
using Site.Domain.Enums;
using RabbitMQ.Client;
using System.Text.Json;
using Site.Domain.Dtos;
using System.Text;

namespace Site.Application.Features.Commands.Payment.PayBill
{
    public class PayBillCommandHandler : IRequestHandler<PayBillCommand, string>
    {
        private readonly IBillPaymentRepository _billPaymentRepository;
        private readonly PayBillValidator _validator;
        private readonly ConnectionFactory factory;
        private readonly IConnection connection;

        public PayBillCommandHandler(IBillPaymentRepository billPaymentRepository)
        {
            _billPaymentRepository = billPaymentRepository;
            _validator = new PayBillValidator();

            factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "test",
                Password = "test"
            };

            connection = factory.CreateConnection();
        }

        public async Task<string> Handle(PayBillCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);


            CreditCardDto creditCard = new CreditCardDto();
            creditCard.UserId = request.UserId;
            creditCard.Pay = request.Pay;
            creditCard.ExpireDate = request.ExpireDate;
            creditCard.Cvc = request.Cvc;
            creditCard.CreditCardNumber = request.CreditCardNumber;

            using (var channel = this.connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: "payment",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var customerPayload = JsonSerializer.Serialize(creditCard);

                var body = Encoding.UTF8.GetBytes(customerPayload);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "payment",
                    basicProperties: null,
                    body: body
                );
            }



            var bill = _billPaymentRepository.GetBillByUserIdAndMonth(request.UserId, request.Month);

            var restOfDept = bill.TotalDept - request.Pay;

            if (restOfDept == 0)
            {
                bill.TotalDept = 0;
                await _billPaymentRepository.UpdateAsync(bill);
                return $"{(MonthEnum)request.Month} ayı faturanız ödenmiştir.";
            }
            else
            {
                bill.TotalDept = restOfDept;
                bill.Electric = restOfDept / 4;
                bill.Water = restOfDept / 4;
                bill.NaturalGas = restOfDept / 4;
                bill.Dues = restOfDept / 4;

                await _billPaymentRepository.UpdateAsync(bill);
                return $"{(MonthEnum)request.Month} ayı faturanızın {request.Pay}tl kadarı ödenmiştir. Kalan borç = {restOfDept}tl.";
            }
        }
    }
}
