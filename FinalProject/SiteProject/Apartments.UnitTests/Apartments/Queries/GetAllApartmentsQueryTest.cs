using AutoMapper;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Apartments.UnitTests.Mocks;
using Site.Application.Mapping;
using Site.Application.Features.Queries.Apartments.GetAllApartments;
using Microsoft.Extensions.Caching.Distributed;

namespace Apartments.UnitTests.Apartments.Queries
{
    public class GetAllApartmentsQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IApartmentRepository> _mocks;

        public GetAllApartmentsQueryTest()
        {
            _mocks = MockApartmentRepository.GetApartmentRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task GetAllApartments()
        {
            //var handler = new GetAllApartmentsQueryHandler(_mocks.Object, _mapper);

        }
    }
}
