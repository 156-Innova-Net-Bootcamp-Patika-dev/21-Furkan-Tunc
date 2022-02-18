using Microsoft.AspNetCore.Identity;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Authentication
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string VehicleInformation { get; set; }
        public List<Apartment> Apartments { get; set; }
        public int ApartmentId { get; set; }
    }
}
