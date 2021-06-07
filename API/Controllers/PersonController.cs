using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PersonController : BaseController<Person, PersonRepository, int>
    {
        PersonRepository repo;
        
       
        public PersonController(PersonRepository person) : base(person)
        {
            this.repo = person;
         
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            var post = repo.Register(registerVM);
            if(post > 0)
            {
                return Ok("Data Berhasil Di Daftarkan");
            }
            else
            {
                return BadRequest("Data Gagal di Masukan");
            }
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(RegisterVM registerVM)
        {
            var login = repo.Login(registerVM);
            if (login > 0)
            {
                return Ok($"Login Berhasil \n Token : {repo.GenerateToken(registerVM)}");
            }
            else
            {
                return BadRequest("Email/Password Salah");
            }

        }

        //[Authorize(Roles = "Admin")]
        [Route("GetAllProfile")]
        [HttpGet]
        [EnableCors("AllowOrigin")]

        public ActionResult GetAllProfile(string token)
        {
            
            var post = repo.GetAllProfile();
            if (post != null)
            {
                return Ok(post);
            }
            else
            {
                return BadRequest("Data Tidak Ditemukan");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetProfilbyId/{nik}")]
        public ActionResult GetProfilbyId(int nik)
        {
            var get = repo.GetProfilbyId(nik);
            if (get !=null)
            {
                return Ok(get);
            }
            else
                return NotFound("Data Tidak Ditemukan");
        }



        //[HttpPost("Login")]
        //public ActionResult ChangePassword(ChangePassword changePassword,int nik)
        //{
        //    var change = repo.Login();
        //    if (change > 0)
        //    {
        //        return Ok("Login Berhasil");
        //    }
        //    else
        //    {
        //        return BadRequest("Email/Password Salah");
        //    }

        //}




    }
}
