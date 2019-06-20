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
    public class LectureController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Lecture
        public ActionResult Index()
        {
            var lectures = db.Lectures.Include(l => l.Member);
            return View(lectures.ToList());
        }

        // GET: Lecture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: Lecture/Create
        public ActionResult Create()
        {
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName");
            return View();
        }

        // POST: Lecture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lectureID,lectureTitle,lectureLanguage,lectureImage,tutorIntroduce,lectureIntroduce,lecturePeople,lecturePlan,lectureCount,lecturePrice,lectureMaxperson,lectureApplyDeadline,lectureLocation,lecturePlace,memberID")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Lectures.Add(lecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", lecture.memberID);
            return View(lecture);
        }

        // GET: Lecture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", lecture.memberID);
            return View(lecture);
        }

        // POST: Lecture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lectureID,lectureTitle,lectureLanguage,lectureImage,tutorIntroduce,lectureIntroduce,lecturePeople,lecturePlan,lectureCount,lecturePrice,lectureMaxperson,lectureApplyDeadline,lectureLocation,lecturePlace,memberID")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.memberID = new SelectList(db.Members, "memberID", "memberName", lecture.memberID);
            return View(lecture);
        }

        // GET: Lecture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lecture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Lectures.Remove(lecture);
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
