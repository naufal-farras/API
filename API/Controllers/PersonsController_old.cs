using API.Models;
using API.Repository;
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
    public class PersonsController_old : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public PersonsController_old(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpPost]
        public ActionResult Post(Person person)
        {
            var post = personRepository.Insert(person);
            if (post > 0)
            {
                return Ok("Data berhasil di Simpan");
            }
            else
            {
                return BadRequest("Data Gagal Tersimpan");
            }
        }
        [HttpGet]
        public ActionResult Get()
        {
            var get = personRepository.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Gagal di Tampilkan");
            }

        }
        [Route("{nik}")]
        public ActionResult Get(int nik)
        {
            var get = personRepository.Get(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Gagal di tampilkan");
            }
        }

        [HttpDelete("{nik}")]
        public ActionResult Delete(int nik)
        {
            var delete = personRepository.Delete(nik);
            if (delete > 0)
            {
                return Ok("Data Berhasil di Hapus");
            }
            else
            {
                return BadRequest("Data Gagal di Hapus");
            }

        }

        [HttpPut]
        public ActionResult Put(Person person)
        {
            var update = personRepository.Update(person);
            if (update > 0)
            {
                return Ok("Data Berhasil di Ubah");
            }
            else
            {
                return BadRequest("Data Gagal di Ubah");

            }
        }

    }
}