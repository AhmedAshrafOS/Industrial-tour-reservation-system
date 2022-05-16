using Industrial_tour_reservation_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.ViewModels
{
    public class PackageViews
    {
        public Package Package { get; set; }

        public List<Subject> Subject_List { get; set; }
        public List<Place> Place_List { get; set; }
    }
}