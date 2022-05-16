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

        public int PackageID { get; set; }

        public int VisitorID { get; set; }

        public string NameOfVisitor { get; set; }

        public string NameOfPackage { get; set; }

        public string NameOfPlace { get; set; }


        //Realtion with Vistor (OneToMany)


    }
}