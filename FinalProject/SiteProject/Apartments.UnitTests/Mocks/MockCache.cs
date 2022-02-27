using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments.UnitTests.Mocks
{
    public static class MockCache
    {
        public static Mock<IDistributedCache> GetDistributedCache()
        {
            //var mockRepo = new Mock<IDistributedCache>();
            //mockRepo.Setup(x => x.Get(It.IsAny<IDistributedCache>))
            //return mockRepo;
        }
    }
}
