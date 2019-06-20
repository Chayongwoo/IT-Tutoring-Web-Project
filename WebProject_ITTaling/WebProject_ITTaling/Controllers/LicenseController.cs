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
    public class LicenseController : Controller
    {
        private DataContext db = new DataContext();

        // GET: License
        public ActionResult Index()
        {
            var licenses = db.Licenses.Include(l => l.Member);
            return View(licenses.ToList());
        }

        // GET: License/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        // GET: License/Create
        public ActionResult Create()
        {
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName");
            return View();
        }

        // POST: License/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "licenseID,licenseName,licenseNumber,licenseAgency,licenseAcqDate,memberID")] License license)
        {
            if (ModelState.IsValid)
            {
                db.Licenses.Add(license);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", license.memberID);
            return View(license);
        }

        // GET: License/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", license.memberID);
            return View(license);
        }

        // POST: License/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "licenseID,licenseName,licenseNumber,licenseAgency,licenseAcqDate,memberID")] License license)
        {
            if (ModelState.IsValid)
            {
                db.Entry(license).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", license.memberID);
            return View(license);
        }

        // GET: License/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            License license = db.Licenses.Find(id);
            if (license == null)
            {
                return HttpNotFound();
            }
            return View(license);
        }

        // POST: License/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            License license = db.Licenses.Find(id);
            db.Licenses.Remove(license);
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
