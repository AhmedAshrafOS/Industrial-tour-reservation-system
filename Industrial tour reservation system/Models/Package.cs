using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string PackageName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string startLocation { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Transport { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public float CostForOne { get; set; }

        public string Description { get; set; }

        public int Min { get; set; }

        public int Hour { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        //Realtion with Subject (OneToMany)
        public int SubjectID { get; set; }
        [ForeignKey("SubjectID")]
        public virtual Subject Subject { get; set; }

        //Realtion with Place (OneToMany)
        public int PlaceID { get; set; }
        [ForeignKey("PlaceID")]
        public virtual Place Place { get; set; }

        //many to many realtion
        public virtual ICollection<VisitorBooking> VisitorBooking { get; set; }

    }
}