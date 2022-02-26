﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Site.WebUI.HttpClients;
using Site.WebUI.Models.Bills;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Site.WebUI.Controllers
{
    public class BillController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var jwt = Request.Cookies["jwt"];

            var token = jwt;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var jwtRole = jwtSecurityToken.Claims.First(claim => claim.Value == "Admin" || claim.Value == "User").Value;

            if (jwt == null)
            {
                ViewData["ErrorMessage"] = "İşlem yapmaya yetkiniz yok!";
                return RedirectToAction("Index", "Home");
            }

            if (jwtRole == "Admin")
            {
                var billJsonAdmin = await MyHttpClient.HttpGet("GET", "Bills/All", jwt);
                var billListAdmin = JsonConvert.DeserializeObject<List<BillListModel>>(billJsonAdmin);
                return View(billListAdmin);
            }

            var billJson = await MyHttpClient.HttpGet("GET", "Bills", jwt);
            var billList = JsonConvert.DeserializeObject<List<BillListModel>>(billJson);
            return View(billList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var jwt = Request.Cookies["jwt"];

            var token = jwt;
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var jwtRole = jwtSecurityToken.Claims.First(claim => claim.Value == "Admin" || claim.Value == "User").Value;

            if (jwtRole != "Admin")
            {
                ViewData["ErrorMessage"] = "İşlem yapmaya yetkiniz yok!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBillModel addBillModel)
        {
            var jsonData = JsonConvert.SerializeObject(addBillModel);

            var jwt = Request.Cookies["jwt"];

            if (jwt == null)
            {
                ViewData["ErrorMessage"] = "İşlem yapmaya yetkiniz yok!";
                return View();
            }

            var result = await MyHttpClient.HttpCommand("POST", jsonData, "Bills", jwt);

            ViewData["Message"] = result;

            return RedirectToAction("Index");
        }
    }
}
