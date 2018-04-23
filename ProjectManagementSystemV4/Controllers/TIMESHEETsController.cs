using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystemV4.Models;

namespace ProjectManagementSystemV4.Controllers
{
    public class TIMESHEETsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: TIMESHEETs
        public ActionResult Index()
        {
            var tIMESHEETs = db.TIMESHEETs.Include(t => t.DELIVERABLE).Include(t => t.EMPLOYEE);
            return View(tIMESHEETs.ToList());
        }

        // GET: TIMESHEETs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMESHEET tIMESHEET = db.TIMESHEETs.Find(id);
            if (tIMESHEET == null)
            {
                return HttpNotFound();
            }
            return View(tIMESHEET);
        }

        // GET: TIMESHEETs/Create
        public ActionResult Create()
        {
            ViewBag.Deliverable_ID = new SelectList(db.DELIVERABLES, "Deliverable_ID", "Name");
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEEs, "Employee_ID", "F_name");
            return View();
        }

        // POST: TIMESHEETs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Timesheet_ID,Week,Hours,Last_update,Last_update_by,Employee_ID,Deliverable_ID")] TIMESHEET tIMESHEET)
        {
            if (ModelState.IsValid)
            {
                db.TIMESHEETs.Add(tIMESHEET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Deliverable_ID = new SelectList(db.DELIVERABLES, "Deliverable_ID", "Name", tIMESHEET.Deliverable_ID);
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEEs, "Employee_ID", "F_name", tIMESHEET.Employee_ID);
            return View(tIMESHEET);
        }

        // GET: TIMESHEETs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMESHEET tIMESHEET = db.TIMESHEETs.Find(id);
            if (tIMESHEET == null)
            {
                return HttpNotFound();
            }
            ViewBag.Deliverable_ID = new SelectList(db.DELIVERABLES, "Deliverable_ID", "Name", tIMESHEET.Deliverable_ID);
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEEs, "Employee_ID", "F_name", tIMESHEET.Employee_ID);
            return View(tIMESHEET);
        }

        // POST: TIMESHEETs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Timesheet_ID,Week,Hours,Last_update,Last_update_by,Employee_ID,Deliverable_ID")] TIMESHEET tIMESHEET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIMESHEET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Deliverable_ID = new SelectList(db.DELIVERABLES, "Deliverable_ID", "Name", tIMESHEET.Deliverable_ID);
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEEs, "Employee_ID", "F_name", tIMESHEET.Employee_ID);
            return View(tIMESHEET);
        }

        // GET: TIMESHEETs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIMESHEET tIMESHEET = db.TIMESHEETs.Find(id);
            if (tIMESHEET == null)
            {
                return HttpNotFound();
            }
            return View(tIMESHEET);
        }

        // POST: TIMESHEETs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIMESHEET tIMESHEET = db.TIMESHEETs.Find(id);
            db.TIMESHEETs.Remove(tIMESHEET);
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
