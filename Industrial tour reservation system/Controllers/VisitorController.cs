using Industrial_tour_reservation_system.Models;
using Industrial_tour_reservation_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Industrial_tour_reservation_system.Controllers
{
    public class VisitorController : Controller
    {
        private DbTour db = new DbTour();

        //_______________Register Functions ____________________
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Visitor Visitor, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/imgs/ProfileVisitor/"), pic);
                    file.SaveAs(path);

                    Visitor.avatar = pic;
                }
                if (db.Visitors.Any(k => k.UserName == Visitor.UserName) || db.Visitors.Any(k => k.Email == Visitor.Email))
                {
                    if (db.Visitors.Any(k => k.UserName == Visitor.UserName))
                    {
                        ViewBag.UserExist = "This UserName Already Exist.";
                    }
                    else
                        ViewBag.EmailExist = "This Email Already Exist.";

                }

                else
                {
                    db.Visitors.Add(Visitor);
                    db.SaveChanges();
                    return RedirectToAction("Login", "MainAdmin");
                }

            }

            return View(Visitor);
        }

        //_______________Register Functions ____________________


        //_______________Login ____________________

        [HttpGet]
        public ActionResult Login(string User)
        {

               var usr = db.Visitors.Where(u => u.UserName == User).FirstOrDefault();

                    Session["UserID"] = usr.VisitorID.ToString();
                    Session["UserName"] = usr.UserName.ToString();
                    return RedirectToAction("MainPage");

        }
        //_______________Login ____________________


        //_______________MainPage ____________________
        public ActionResult MainPage()
        {
            if (Session["UserName"] != null)
            {
                var All_Subjects = db.Subjects.ToList();
                var All_Places = db.Places.ToList();
                PackageViews PackageViews= new PackageViews()
                {
                    Place_List= All_Places,
                    Subject_List= All_Subjects,
                };
                return View(PackageViews);
            }
            else
            {
                return RedirectToAction("Login", "MainAdmin");
            }
        }

        //_______________MainPage ____________________

        //_______________VisitorBooking ____________________
        [HttpGet]
        public ActionResult Booking()
        {
            var username = Session["UserName"].ToString();
            var user = db.Visitors.SingleOrDefault(x => x.UserName == (string)username);
            List<Package> Spcify_Package = new List<Package>();
            var All_Package = db.Packages.ToList();
            var All_Bookings = db.VisitorBookings.ToList();

            if (All_Bookings.Count == 0)
            {
                Spcify_Package = All_Package;
            }
            else
            {
            
                foreach (var item in All_Package)
                {
                        foreach(var item2 in All_Bookings)
                        {
                            if (user.VisitorID == item2.VisitorID && item2.PackageID == item.PackageID) 
                            {
                        
                            }
                            else
                            {
                                Spcify_Package.Add(item);
                            }
                        }
                }
            }

            UserBookingView UserBookingView = new UserBookingView
            {
                Visitor= user,
               Package_List = Spcify_Package,
            };

            return View(UserBookingView);
        }



        [HttpPost]
        public ActionResult Booking(UserBookingView UserBookingView)
        {
            if (Session["UserName"] != null)
            {
                
                var Packge = db.Packages.Find(UserBookingView.Package.PackageID);
                var Visitor = db.Visitors.Find(UserBookingView.Visitor.VisitorID);

                Booking new_Booking = new Booking()
                {
                    NameOfVisitor = Visitor.FirstName+" "+ Visitor.LastName,
                    NameOfPackage = Packge.PackageName,
                    NameOfPlace= Packge.Place.Country +" "+Packge.Place.City+" "+Packge.Place.Street,
                    VisitorID=Visitor.VisitorID,
                    PackageID= Packge.PackageID

                };
                VisitorBooking VisitorBooking = new VisitorBooking
                {
                    VisitorID = UserBookingView.Visitor.VisitorID,
                    PackageID= UserBookingView.Package.PackageID,
                    
                
                    
                };
                db.VisitorBookings.Add(VisitorBooking);
                db.Bookings.Add(new_Booking);
                db.SaveChanges();
                return RedirectToAction("MainPage");

            }
            else
            {
                return RedirectToAction("Login", "MainAdmin");
            }
        }

        //_______________VisitorBooking ____________________



        //_______________View His Bookings ____________________
        [HttpGet]
        public ActionResult MyBookings()
        {
            if (Session["UserName"] != null)
            {
                List<int> HisBookings = new List<int>();
                List<Package> HisPackages = new List<Package>();
                var username = Session["UserName"].ToString();
                var user = db.Visitors.SingleOrDefault(x => x.UserName == (string)username);
                var All_Bookings = db.VisitorBookings.ToList();
                var All_Packages = db.Packages.ToList();

                foreach (var item in All_Bookings)
                {
                    if (user.VisitorID == item.VisitorID)
                    {
                        HisBookings.Add(item.PackageID);
                    }
                }

                foreach (var item in HisBookings)
                {
                    foreach (var item2 in All_Packages)
                    {
                        if (item == item2.PackageID)
                        {
                            HisPackages.Add(item2);
                        }
                    }

                }
                UserBookingView UserBookingView = new UserBookingView
                {
                    Visitor = user,
                    Package_List = HisPackages,
                };


                return View(UserBookingView);

            }
            else
            {
                return RedirectToAction("Login", "MainAdmin");
            }
        }

        //_______________View His Bookings ____________________
    }
}
