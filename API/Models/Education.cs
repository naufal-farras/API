﻿using System;
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
            public int id { get; set; }
            public string Degree { get; set; }
            public string GPA { get; set; }
            public string University_id { get; set; }
             public University University { get; set; }
             public ICollection<Profiling> Profiling { get; set; }

        //public virtual Profiling Profiling { get; set; }


    }
}
