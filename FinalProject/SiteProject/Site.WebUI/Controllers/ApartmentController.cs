using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.WebUI.HttpClients;
using Site.WebUI.Models.Apartments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Site.WebUI.Controllers
{
    public class ApartmentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var apartmentJson = await MyHttpClient.MyHttpGet("GET", "Apartments");
            var apartmentList = JsonConvert.DeserializeObject<List<ApartmentListModel>>(apartmentJson);

            return View(apartmentList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddApartmentModel addApartmentModel)
        {
            var jsonData = JsonConvert.SerializeObject(addApartmentModel);
            var result = await MyHttpClient.MyHttpCommand("POST", jsonData, "Apartments");

            if (result == null)
            {
                TempData["ErorMesaj"] = "İşlem başarısız oldu!";
                return View(addApartmentModel);
            }
            TempData["SuccessMesaj"] = "İşlem başarıyla gerçekleşti";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var apartmentJson = await MyHttpClient.MyHttpGet("GET", $"Apartments/{id}");
            var apartment = JsonConvert.DeserializeObject<UpdateApartmentModel>(apartmentJson);

            return View(apartment);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateApartmentModel updateApartmentModel)
        {
            var jsonData = JsonConvert.SerializeObject(updateApartmentModel);
            var result = await MyHttpClient.MyHttpCommand("PUT", jsonData, "Apartments");

            if (result == null)
            {
                TempData["ErorMesaj"] = "İşlem başarısız oldu!";
                return View(updateApartmentModel);
            }
            TempData["SuccessMesaj"] = "İşlem başarıyla gerçekleşti";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jsonData = JsonConvert.SerializeObject(id);
            var apartmentJson = await MyHttpClient.MyHttpCommand("DELETE", jsonData, $"Apartments/{id}");

            return RedirectToAction("Index");
        }

    }
}
