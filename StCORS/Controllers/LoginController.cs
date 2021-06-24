using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class LoginController : BaseController<Person, PersonRepository, int>
    {
        PersonRepository repository;
        LoginRepository loginRep;


        public LoginController(PersonRepository repository, LoginRepository loginRep) : base(repository)
        {
            this.repository = repository;
            this.loginRep = loginRep;

        }
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");

        }


        public IActionResult Index2()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Auth(LoginVM loginVM)
        {
            var jwToken = await loginRep.Auth(loginVM);
            if (jwToken == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", jwToken.Token);
            return RedirectToAction("index", "home");
        }

    }
}
