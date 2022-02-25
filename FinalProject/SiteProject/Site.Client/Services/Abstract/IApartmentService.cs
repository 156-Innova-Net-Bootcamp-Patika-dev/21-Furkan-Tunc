using Site.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Client.Services.Abstract
{
    public interface IApartmentService
    {
        Task<List<ApartmentModel>> GetAllApartments();
    }
}
