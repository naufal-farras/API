using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Education")]
    public class Education
    {
        [Key]
        public int Educationid { get; set; }
        public string Degree { get; set; }
        public string GPA { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Profiling> Profiling { get; set; }

        public int Universityid { get; set; }



    }
}
