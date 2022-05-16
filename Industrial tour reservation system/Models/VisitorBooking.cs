using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Models
{
    public class VisitorBooking
    {
        public int VisitorID { get; set; }
        [ForeignKey("VisitorID")]
        public virtual Visitor Visitor { get; set; }


        public int PackageID { get; set; }
        [ForeignKey("PackageID")]
        public virtual Package Package { get; set; }
    }
}