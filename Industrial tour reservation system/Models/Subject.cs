using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }


        public virtual ICollection<Package> Packages { get; set; }

    }
}