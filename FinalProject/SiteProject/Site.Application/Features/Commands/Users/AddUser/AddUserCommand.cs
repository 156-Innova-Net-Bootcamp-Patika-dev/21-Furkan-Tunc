using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.AddUser
{
    public class AddUserCommand:IRequest<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VehicleInformation { get; set; }
    }
}
