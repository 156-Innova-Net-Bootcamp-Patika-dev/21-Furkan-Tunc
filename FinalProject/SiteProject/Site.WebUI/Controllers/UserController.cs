using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.WebUI.HttpClients;
using Site.WebUI.Models.Users;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Site.WebUI.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var jwt = Request.Cookies["jwt"];

            var token = jwt;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var jwtRole = jwtSecurityToken.Claims.First(claim => claim.Value == "Admin" || claim.Value == "User").Value;


            if (jwt == null || jwtRole != "Admin")
            {
                ViewData["ErrorMessage"] = "İşlem yapmaya yetkiniz yok!";
                return RedirectToAction("Index", "Home");
            }

            var userJson = await MyHttpClient.HttpGet("GET", "Users",jwt);
            var userList = JsonConvert.DeserializeObject<List<UserListModel>>(userJson);
            
            return View(userList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddUserModel addUserModel)
        {
            var jsonData = JsonConvert.SerializeObject(addUserModel);

            var jwt = Request.Cookies["jwt"];

            if (jwt == null)
            {
                ViewData["ErrorMessage"] = "İşlem yapmaya yetkiniz yok!";
                return View();
            }

            var result = await MyHttpClient.HttpCommand("POST", jsonData, "Users",jwt);//result da pin geliyor bunu kullanıcıya göster

            ViewData["Message"] = result;

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var jwt = Request.Cookies["jwt"];

            var userJson = await MyHttpClient.HttpGet("GET", $"Users/{id}",jwt);
            var user = JsonConvert.DeserializeObject<UpdateUserModel>(userJson);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserModel updateUserModel)
        {
            var jsonData = JsonConvert.SerializeObject(updateUserModel);
            var jwt = Request.Cookies["jwt"];
            var result = await MyHttpClient.HttpCommand("PUT", jsonData, "Users",jwt);

            ViewData["Message"] = result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var jwt = Request.Cookies["jwt"];
            var jsonData = JsonConvert.SerializeObject(id);
            var result = await MyHttpClient.HttpCommand("DELETE", jsonData, $"Users/{id}", jwt);

            ViewData["Message"] = result;

            return RedirectToAction("Index");
        }
    }
}
