﻿using System.Web;
using System.Web.Mvc;

namespace Industrial_tour_reservation_system
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
