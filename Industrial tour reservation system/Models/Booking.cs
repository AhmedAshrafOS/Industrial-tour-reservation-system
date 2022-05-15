using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required(ErrorMessage = "This Feild is Requierd")]
        public string BookingName { get; set; }
        [Required(ErrorMessage = "This Feild is Requierd")]
        public float TotalCost { get; set; }

        [Required(ErrorMessage = "This Feild is Requierd")]
        public int NumOfVistors { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int Hour { get; set; }

        public int Minuit { get; set; }

        //Realtion with Vistor (OneToMany)
        public int VisitorID { get; set; }
        [ForeignKey("VisitorID")]
        public virtual Visitor Visitor { get; set; }

    }
}