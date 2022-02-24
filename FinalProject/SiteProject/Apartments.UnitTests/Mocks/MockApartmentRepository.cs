using Moq;
using Site.Application.Contracts.Persistence.Repositories.Apartments;
using Site.Domain.Entities;
using System.Collections.Generic;

namespace Apartments.UnitTests.Mocks
{
    public static class MockApartmentRepository
    {
        public static Mock<IApartmentRepository> GetUserRepository()
        {
            var apartmentList = new List<Apartment>()
            {
                new Apartment() {ID=1,Blok=1,ApartmentNumber=1,Floor=1,Owner="Furkan",Type="2+1",UserId=1,Status="Dolu"},
                new Apartment() {ID=2,Blok=2,ApartmentNumber=2,Floor=2,Owner="Ali",Type="2+1",UserId=2,Status="Dolu"},
                new Apartment() {ID=3,Blok=3,ApartmentNumber=3,Floor=3,Owner="Veli",Type="2+1",UserId=3,Status="Dolu"}
            };

            var mockRepo = new Mock<IApartmentRepository>();

            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(apartmentList);

            //mockRepo.Setup(x => x.AddAsync(It.IsAny<Apartment>())).Returns((Apartment apartment) =>
            //  {
            //      apartmentList.Add(apartment);
            //      return apartment;
            //  });

            return mockRepo;
        }
    }
}
