﻿using API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public  class RegisterVM
    {
        public int NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public virtual Account Account { get; set; }
        //[JsonIgnore]
        public int Salary { get; set; }

        public string Password { get; set; }

        public string Degree { get; set; }
        public string GPA { get; set; }
        public int Universityid { get; set; }
    
        public int RoleId { get; set; }
        



    }
}
