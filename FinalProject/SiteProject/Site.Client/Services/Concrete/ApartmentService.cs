using Site.Client.Extensions;
using Site.Client.Models;
using Site.Client.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Site.Client.Services.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly HttpClient _client;
        public ApartmentService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<ApartmentModel>> GetAllApartments()
        {
            var response = await _client.GetAsync("/api/Apartments");
            return await response.ReadContentAs<List<ApartmentModel>>();
        }
    }
}
