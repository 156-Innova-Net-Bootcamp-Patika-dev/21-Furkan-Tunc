using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Text;
using Site.Domain.Dtos;

namespace RabbitMqConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.UserName = "test";
            factory.Password = "test";

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume("payment", false, consumer);
                consumer.Received += (sender, e) =>
                {

                    var body = e.Body.ToArray();
                    var jsonString = Encoding.UTF8.GetString(body);
                    var oku = JsonConvert.DeserializeObject<CreditCardDto>(jsonString);

                    Console.WriteLine($"Json receievd as {oku.CreditCardNumber}");

                    channel.BasicAck(e.DeliveryTag, false);
                };
                Console.Read();
            }
        }
    }
}
