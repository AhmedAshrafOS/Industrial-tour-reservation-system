using Industrial_tour_reservation_system.Models;
using Industrial_tour_reservation_system.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Industrial_tour_reservation_system.Controllers
{
    public class MainAdminController : Controller
    {
        /// <Conustructors> Initialize
        private DbTour db;
        private readonly Main MainInterFace;

        public MainAdminController()
        {
            MainInterFace = new Main();
            db = new DbTour();
        }
        /// </Conustructors>
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin AdminData)
        {
            var isLoggedIn = MainInterFace.Login(AdminData.AdminName, AdminData.Password);
            if (isLoggedIn==1)
            {
                return RedirectToAction("LoggedIn", "MainAdmin");
            }
            if (isLoggedIn == 2)
            {
                return RedirectToAction("Login", "Visitor", new { User = AdminData.AdminName });
                //return RedirectToAction("Login", "Visitor");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");

            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            return View();
        }
    }
}