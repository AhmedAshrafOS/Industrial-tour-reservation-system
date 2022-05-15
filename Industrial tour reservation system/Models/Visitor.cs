using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class Visitor
    {
        [Key]
        public int VisitorID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Feild is Requierd")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is Required")]
        [Compare("Password", ErrorMessage = "Password Must Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Visitor Image")]
        public string avatar { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }


    }
}