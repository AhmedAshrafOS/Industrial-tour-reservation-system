using Industrial_tour_reservation_system.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Industrial_tour_reservation_system.Controllers
{
    public class AdminPlacesController : Controller
    {
        private DbTour db = new DbTour();

        //List Of ALL Index
        public ActionResult Index()
        {
            List<Place> All_Place = db.Places.ToList();

            return View(All_Place);
        }

        //List Of ALL Index


        [HttpGet]
        public ActionResult CreatePlace()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreatePlace(Place newPlace, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/imgs/PlaceImages/"), pic);
                    file.SaveAs(path);
                    newPlace.Image = pic;
                }


                db.Places.Add(newPlace);

                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View();


        }


        public ActionResult PlaceDetails(int id)
        {

            Place Current_Place = db.Places.SingleOrDefault(x => x.PlaceID == id);

            if (Current_Place == null)
            {
                return HttpNotFound();
            }
            return View(Current_Place);
        }


        [HttpGet]
        public ActionResult EditPlace(int? id)
        {
            if (id != null)
            {
                Place Current_Place = db.Places.SingleOrDefault(x => x.PlaceID == id);
                if (Current_Place == null)
                {
                    return HttpNotFound();
                }


                return View(Current_Place);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult EditPlace(Place Edited_Place, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var Current_Place = db.Places.SingleOrDefault(a => a.PlaceID == Edited_Place.PlaceID);
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/imgs/PlaceImages/"), pic);
                    file.SaveAs(path);
                    Current_Place.Image = pic;
                }


                Current_Place.companyName = Edited_Place.companyName;
                Current_Place.Country = Edited_Place.Country;
                Current_Place.City = Edited_Place.City;
                Current_Place.Street = Edited_Place.Street;



                db.Entry(Current_Place).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("PlaceDetails", new { id = Current_Place.PlaceID });
            }
            return View();
        }

        // POST: Director/Delete/5
        [HttpGet]
        public ActionResult DeletePlace(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Place Current_Place = db.Places.Find(id);
            if (Current_Place == null)
                return HttpNotFound();

            return View(Current_Place);
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult DeletePlace(Place Current_Place)
        {
            try
            {
                if (Current_Place.PlaceID == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var Deleted_Place = db.Places.Find(Current_Place.PlaceID);
                if (Deleted_Place == null)
                    return HttpNotFound();
                db.Places.Remove(Deleted_Place);
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