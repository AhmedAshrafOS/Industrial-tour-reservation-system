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
    public class AdminSubjectController : Controller
    {
        private DbTour db = new DbTour();

        //List Of ALL Index
        public ActionResult Index()
        {
            List<Subject> All_Subjects = db.Subjects.ToList();

            return View(All_Subjects);
        }

        //List Of ALL Index


        [HttpGet]
        public ActionResult CreateSubject()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateSubject(Subject newSubject)
        {
            if (ModelState.IsValid)
            {



                db.Subjects.Add(newSubject);

                db.SaveChanges();


                return RedirectToAction("Index");

            }
            return View();


        }


        public ActionResult SubjectDetails(int id)
        {

            Subject Current_Subject = db.Subjects.SingleOrDefault(x => x.SubjectID == id);

            if (Current_Subject == null)
            {
                return HttpNotFound();
            }
            return View(Current_Subject);
        }


        [HttpGet]
        public ActionResult EditSubject(int? id)
        {
            if (id != null)
            {
                Subject Current_Subject = db.Subjects.SingleOrDefault(x => x.SubjectID == id);
                if (Current_Subject == null)
                {
                    return HttpNotFound();
                }


                return View(Current_Subject);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult EditSubject(Subject Edited_Subject)
        {
            if (ModelState.IsValid)
            {
                var Current_Subject = db.Subjects.SingleOrDefault(a => a.SubjectID == Edited_Subject.SubjectID);

                Current_Subject.Name = Edited_Subject.Name;


                db.Entry(Current_Subject).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("SubjectDetails", new { id = Current_Subject.SubjectID });
            }
            return View();
        }

        // POST: Director/Delete/5
        [HttpGet]
        public ActionResult DeleteSubject(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Subject Current_Subject = db.Subjects.Find(id);
            if (Current_Subject == null)
                return HttpNotFound();

            return View(Current_Subject);
        }

        // POST: Director/Delete/5
        [HttpPost]
        public ActionResult DeleteSubject(Subject Current_Subject)
        {
            try
            {
                if (Current_Subject.SubjectID == 0)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                var Deleted_Subject = db.Subjects.Find(Current_Subject.SubjectID);
                if (Current_Subject == null)
                    return HttpNotFound();
                db.Subjects.Remove(Deleted_Subject);
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