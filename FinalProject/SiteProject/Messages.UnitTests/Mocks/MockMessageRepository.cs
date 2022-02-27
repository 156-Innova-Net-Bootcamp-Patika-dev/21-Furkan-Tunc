using Moq;
using Site.Application.Contracts.Persistence.Repositories.Messages;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.UnitTests.Mocks
{
    public static class MockMessageRepository
    {
        public static Mock<IMessageRepository> GetMessageRepository()
        {
            var messageList = new List<Message>()
            {
                new Message() {ID=1,Content="Merhaba",From="furkan@furkan.com",To="ahmet@ahmet.com",Read=true},
                new Message() {ID=2,Content="Selam",From="ahmet@ahmet.com",To="furkan@furkan.com",Read=true}
            };

            var mockRepo = new Mock<IMessageRepository>();

            mockRepo.Setup(x => x.AddAsync(It.IsAny<Message>())).Callback((Message message) =>
            {
                messageList.Add(message);
            });

            return mockRepo;
        }
    }
}
