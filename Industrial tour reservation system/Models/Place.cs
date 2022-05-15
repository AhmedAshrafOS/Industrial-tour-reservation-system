using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class Place
    {
        [Key]
        public int PlaceID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string companyName { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Visitor Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public virtual ICollection<Package> Packages { get; set; }



    }
}