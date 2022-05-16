using Industrial_tour_reservation_system.Models;
using Industrial_tour_reservation_system.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Industrial_tour_reservation_system.Controllers
{
    public class AdminPackgeController : Controller
    {
        private DbTour db = new DbTour();
        // GET: AdminMovie
        [HttpGet]
        public ActionResult Index()
        {
            List<Package> All_Package = db.Packages.ToList();
            return View(All_Package);
        }


        [HttpGet]
        public ActionResult CreatePackage()
        {
            var All_Subjects = db.Subjects.ToList();
            var All_Places = db.Places.ToList();
            PackageViews package_precondtions = new PackageViews
            {
                    Place_List=All_Places,
                    Subject_List=All_Subjects,
            };


            //ViewBag.ActorId = new SelectList(db.Actors, "ActorId", "FirstName");

            return View(package_precondtions);
        }
        [HttpPost]
        public ActionResult CreatePackage(PackageViews New_Package)
        {
            if (ModelState.IsValid)
            {

                db.Packages.Add(New_Package.Package);
                db.SaveChanges();


                return RedirectToAction("Index");

            }
            return View();

        }

        public ActionResult DetailsPackage(int id)
        {
            var Current_Package = db.Packages.SingleOrDefault(x => x.PackageID == id);

            if (Current_Package == null)
            {
                return HttpNotFound();
            }
            return View(Current_Package);
        }

        [HttpGet]
        public ActionResult EditPackage(int? id)
        {
            if (id != null)
            {
                var Current_Package = db.Packages.SingleOrDefault(x => x.PackageID == id);
                var All_Subjects = db.Subjects.ToList();
                var All_Places = db.Places.ToList();

                PackageViews package_precondtions = new PackageViews
                {
                    Package = Current_Package,
                    Subject_List = All_Subjects,
                    Place_List = All_Places,

                };

                return View(package_precondtions);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult EditPackage(PackageViews Edited_Package)
        {
            if (ModelState.IsValid)
            {
                var Current_Package = db.Packages.SingleOrDefault(a => a.PackageID == Edited_Package.Package.PackageID);

                Current_Package.PackageName = Edited_Package.Package.PackageName;
                Current_Package.startLocation = Edited_Package.Package.startLocation;
                Current_Package.Transport = Edited_Package.Package.Transport;
                Current_Package.CostForOne = Edited_Package.Package.CostForOne;
                Current_Package.Description = Edited_Package.Package.Description;
                Current_Package.Min = Edited_Package.Package.Min;
                Current_Package.Hour = Edited_Package.Package.Hour;
                Current_Package.Day = Edited_Package.Package.Day;
                Current_Package.Month = Edited_Package.Package.Month;
                Current_Package.Year = Edited_Package.Package.Year;
                Current_Package.Subject = Edited_Package.Package.Subject;
                Current_Package.Place = Edited_Package.Package.Place;


                db.Entry(Current_Package).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("DetailsPackage", new { id = Current_Package.PackageID });
            }
            return View();
        }

        // POST: Director/Delete/5

        public ActionResult DeletePackage(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Package Current_Package = db.Packages.Find(id);
            if (Current_Package == null)
                return HttpNotFound();

            return View(Current_Package);
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult DeletePackage(Package Current_Package)
        {
            try
            {
                if (Current_Package.PackageID == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                Package Deleted_Package = db.Packages.Find(Current_Package.PackageID);

                if (Deleted_Package == null)
                    return HttpNotFound();

                db.Packages.Remove(Deleted_Package);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

    }
}