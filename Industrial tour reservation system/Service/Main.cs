using Industrial_tour_reservation_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Industrial_tour_reservation_system.Service
{
    public interface IMainServices
    {
        int Login(string User, string Password);
    }
    public class Main : IMainServices
    {
        public DbTour context { get; set; }

        public Main()
        {
            context = new DbTour();
        }

        public int Login(string User, string Password)
        {
            int Check_Validate;
            if (context.Admins.Where(a => a.AdminName == User && a.Password == Password).Any())
            {
                Check_Validate = 1;
            }
            else if (context.Visitors.Where(a => a.UserName == User && a.Password == Password).Any())
            {
                Check_Validate = 2;
            }
            else
            {
                Check_Validate = 0;
            }
            return (Check_Validate);
        }
    }
}