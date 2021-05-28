using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{

    [Table("TB_M_University")]
    public class University
    {
        [Key]
        public int University_Id { get; set; }
        public string UniversityName { get; set; }
        public virtual ICollection<Education> Education { get; set; }


    }
}
