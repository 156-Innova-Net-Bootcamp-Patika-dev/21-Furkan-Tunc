using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Models.User
{
    public class GetUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TcNo { get; set; }
        public string VehicleInformation { get; set; }
        public int ApartmentId { get; set; }
    }
}
