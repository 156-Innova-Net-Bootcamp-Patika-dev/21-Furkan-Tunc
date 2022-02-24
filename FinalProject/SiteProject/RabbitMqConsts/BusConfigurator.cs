using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

namespace RabbitMqConsts
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(RabbitMqConst.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConst.UserName);
                    hst.Password(RabbitMqConst.Password);
                });

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
