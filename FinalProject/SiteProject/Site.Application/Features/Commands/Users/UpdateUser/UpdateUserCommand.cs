﻿using MediatR;

namespace Site.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VehicleInformation { get; set; }
        public string PhoneNumber { get; set; }
        public int ApartmentId { get; set; }
    }
}
