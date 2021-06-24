using API.Base;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
        [EnableCors("AllowOrigin")]

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

        [EnableCors("AllowOrigin")]
        [HttpPut("UpdateProfile")]
        public ActionResult UpdateProfile(RegisterVM registerVM)
        {
            var update = repo.UpdateProfile(registerVM);
            if (update > 0)
            {
                return Ok("Data Berhasil Di Update");
            }
            else
            {
                return BadRequest("Data Gagal di Update");
            }
        }
        [Route("Login")]
        [HttpPost]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = repo.Login(loginVM);
            if (login == 404)
            {
                return BadRequest("Email Tidak Ditemukan!");
            }
            else if (login == 401)
            {
                return BadRequest("Password Salah");
            }
            else if (login == 1)
            {
                //return Ok($"Login Berhasil \n Token : {repo.GenerateToken(loginVM)}");
                return Ok(new JWTokenVM { Token = repo.GenerateToken(loginVM), Messages ="Login Sukses" });


            }
            else 
            {
                return BadRequest("Login Gagal");
            }

        }

        //[Authorize(Roles = "Admin")]
        [Route("GetAllProfile")]
        [EnableCors("AllowOrigin")]
        [HttpGet]

        //public ActionResult GetAllProfile(string token)
        public ActionResult GetAllProfile()
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

        //[Authorize(Roles = "Admin")]
        [EnableCors("AllowOrigin")]
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


        [EnableCors("AllowOrigin")]
        [HttpPost("DeleteProfilbyId/{nik}")]
        public ActionResult DeleteProfilbyId(int nik)
        {
            var del = repo.DeleteProfilbyId(nik);
            if (del != 0)
            {
                return Ok(del);
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
