using Microsoft.AspNetCore.Identity;
using Moq;
using Site.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.UnitTest.Mocks
{
    public static class MockUserRepository
    {
        public static Mock<UserManager<User>> GetUserRepository()
        {
            var userList = new List<User>()
            {
                new User(){FirstName="furkan",LastName="tunç",Email="furkan@furkan.com",PhoneNumber="123456789",ApartmentId=1,TcNo="987654321"},
                new User(){FirstName="ali",LastName="tunç",Email="ali@furkan.com",PhoneNumber="123456789",ApartmentId=2,TcNo="987654321"},
                new User(){FirstName="veli",LastName="tunç",Email="veli@furkan.com",PhoneNumber="123456789",ApartmentId=3,TcNo="987654321"}
            };

            var mockRepo = new Mock<UserManager<User>>();

            //mockRepo.Setup(u => u.CreateAsync(It.IsAny<User>())).ReturnsAsync((User user) =>
            //  {
            //      userList.Add(user);
            //      return user;
            //  });

            return mockRepo;
        }
    }
}
