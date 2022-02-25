using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Site.Client.Models;
using Site.Client.Services.Abstract;

namespace Site.Client.Pages
{
    public class ApartmentsModel : PageModel
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsModel(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public List<ApartmentModel> ApartmentModel { get; set; }

        public void OnGet()
        {
            ApartmentModel = _apartmentService.GetAllApartments().Result;
        }
    }
}
