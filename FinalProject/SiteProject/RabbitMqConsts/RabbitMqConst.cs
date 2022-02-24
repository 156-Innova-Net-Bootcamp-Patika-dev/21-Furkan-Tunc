using System;

namespace RabbitMqConsts
{
    public class RabbitMqConst
    {
        public const string RabbitMqUri = "rabbitmq://localhost/";
        public const string UserName = "test";
        public const string Password = "test";
        public const string PayServiceQueue = "pay.service";
        public const string NotificationServiceQueue = "notification.service";
        public const string ThirdPartyServiceQueue = "thirdparty.service";
    }
}
