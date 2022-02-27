using AutoMapper;
using Messages.UnitTests.Mocks;
using Moq;
using Site.Application.Contracts.Persistence.Repositories.Messages;
using Site.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Messages.UnitTests.Messages.Queries
{
    public class GetAllMessageQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMessageRepository> _mocks;

        public GetAllMessageQueryTest()
        {
            _mocks = MockMessageRepository.GetMessageRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);

        }

        [Fact]
        public async Task GetAllMessage_Should_ReturnMessageDto()
        {

        }
    }
}
