using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProject_ITTaling.DAL;
using WebProject_ITTaling.Models;

namespace WebProject_ITTaling.Controllers
{
    public class ApplyScheduleController : Controller
    {
        private DataContext db = new DataContext();

        // GET: ApplySchedule
        public ActionResult Index()
        {
            var applySchedules = db.ApplySchedules.Include(a => a.Application);
            return View(applySchedules.ToList());
        }

        // GET: ApplySchedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplySchedule applySchedule = db.ApplySchedules.Find(id);
            if (applySchedule == null)
            {
                return HttpNotFound();
            }
            return View(applySchedule);
        }

        // GET: ApplySchedule/Create
        public ActionResult Create()
        {
            ViewBag.applicationID = new SelectList(db.Applications, "applicationID", "applicationLevel");
            return View();
        }

        // POST: ApplySchedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "applyScheduleID,applyDayofweek,applyScheduleTime,applicationID")] ApplySchedule applySchedule)
        {
            if (ModelState.IsValid)
            {
                db.ApplySchedules.Add(applySchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.applicationID = new SelectList(db.Applications, "applicationID", "applicationLevel", applySchedule.applicationID);
            return View(applySchedule);
        }

        // GET: ApplySchedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplySchedule applySchedule = db.ApplySchedules.Find(id);
            if (applySchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.applicationID = new SelectList(db.Applications, "applicationID", "applicationLevel", applySchedule.applicationID);
            return View(applySchedule);
        }

        // POST: ApplySchedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "applyScheduleID,applyDayofweek,applyScheduleTime,applicationID")] ApplySchedule applySchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applySchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.applicationID = new SelectList(db.Applications, "applicationID", "applicationLevel", applySchedule.applicationID);
            return View(applySchedule);
        }

        // GET: ApplySchedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplySchedule applySchedule = db.ApplySchedules.Find(id);
            if (applySchedule == null)
            {
                return HttpNotFound();
            }
            return View(applySchedule);
        }

        // POST: ApplySchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplySchedule applySchedule = db.ApplySchedules.Find(id);
            db.ApplySchedules.Remove(applySchedule);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
