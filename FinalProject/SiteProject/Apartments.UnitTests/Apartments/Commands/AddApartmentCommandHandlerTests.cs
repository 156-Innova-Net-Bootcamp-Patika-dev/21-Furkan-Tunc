using Apartments.UnitTests.Mocks;
using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Application.Features.Commands.Apartments.AddApartment;
using Site.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Apartments.UnitTests.Apartments.Commands
{
    public class AddApartmentCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IApartmentRepository> _mocks;

        public AddApartmentCommandHandlerTests()
        {
            _mocks = MockApartmentRepository.GetApartmentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task AddApartment()
        {
            //var handler = new 
        }
    }
}
