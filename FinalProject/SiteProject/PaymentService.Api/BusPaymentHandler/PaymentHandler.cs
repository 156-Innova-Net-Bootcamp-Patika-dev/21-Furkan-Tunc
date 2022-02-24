using PaymentService.Application.Contracts.Persistence.Repositories.CreditCards;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Api.BusPaymentHandler
{
    public class PaymentHandler
    {
        private readonly ICreditCardRepository _creditCardRepository;

        public PaymentHandler(ICreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public void Payment()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("payment", false, consumer);
                consumer.Received += (sender, e) =>
                {

                    var body = e.Body.ToArray();
                    var jsonString = Encoding.UTF8.GetString(body);

                    channel.BasicAck(e.DeliveryTag, false);
                };
            }

        }
    }
}
