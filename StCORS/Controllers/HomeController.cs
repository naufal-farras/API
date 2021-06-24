using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StCORS.Base;
using StCORS.Models;
using StCORS.Repository.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StCORS.Controllers
{
    [Authorize]

    public class HomeController : BaseController<Person, PersonRepository, int>
    {
        PersonRepository repository;

        public HomeController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Pokemon()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<JsonResult> Getsemuadata()
        {
            var result = await repository.GetAllProfile();
            return Json(result);
        }

        public async Task<JsonResult> GetProfilbyId(int id)
        {
            var get = await repository.GetProfilbyId(id);
            return Json(get);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

//    public class HomeController : BaseController<Person, PersonRepository, int>
//    {
//        PersonRepository repository;

//        public HomeController(PersonRepository repository) : base(repository)
//        {
//            this.repository = repository;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
//        public IActionResult Testing()
//        {
//            return View();
//        }
//        public IActionResult Profile()
//        {
//            return View();
//        }

//        public IActionResult Pokemon()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }
//        public async Task<JsonResult> Getsemuadata()
//        {
//            var result = await repository.GetAllProfile();
//            return Json(result);
//        }

//    }
//}

