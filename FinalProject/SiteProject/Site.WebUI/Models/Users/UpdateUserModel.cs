﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.WebUI.Models.Users
{
    public class UpdateUserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VehicleInformation { get; set; }
        public string PhoneNumber { get; set; }
        public int ApartmentId { get; set; }
    }
}
