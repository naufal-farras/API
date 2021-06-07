using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;

namespace API.Models
{
    [Table("TB_M_Person")]
    public class Person
    {
        [Key]
        public int NIK { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }

        [JsonIgnore]
        public virtual Account Account { get; set; }

      

        

       
    }
   
}
