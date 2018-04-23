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
    public class DELIVERABLEsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: DELIVERABLEs
        public ActionResult Index()
        {
            var dELIVERABLES = db.DELIVERABLES.Include(d => d.PROJECT);
            return View(dELIVERABLES.ToList());
        }

        // GET: DELIVERABLEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DELIVERABLE dELIVERABLE = db.DELIVERABLES.Find(id);
            if (dELIVERABLE == null)
            {
                return HttpNotFound();
            }
            return View(dELIVERABLE);
        }

        // GET: DELIVERABLEs/Create
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Create()
        {
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name");
            return View();
        }

        // POST: DELIVERABLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Deliverable_ID,Deliverable_deadline,Deliverable_end_date,Deliverable_start_date,Name,Budget,Estimated_manhours,Manhours_charged,Last_update,Last_update_by,Project_ID,Progress_status")] DELIVERABLE dELIVERABLE)
        {
            if (ModelState.IsValid)
            {
                db.DELIVERABLES.Add(dELIVERABLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", dELIVERABLE.Project_ID);
            return View(dELIVERABLE);
        }

        // GET: DELIVERABLEs/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DELIVERABLE dELIVERABLE = db.DELIVERABLES.Find(id);
            if (dELIVERABLE == null)
            {
                return HttpNotFound();
            }
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", dELIVERABLE.Project_ID);
            return View(dELIVERABLE);
        }

        // POST: DELIVERABLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Deliverable_ID,Deliverable_deadline,Deliverable_end_date,Deliverable_start_date,Name,Budget,Estimated_manhours,Manhours_charged,Last_update,Last_update_by,Project_ID,Progress_status")] DELIVERABLE dELIVERABLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dELIVERABLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", dELIVERABLE.Project_ID);
            return View(dELIVERABLE);
        }

        // GET: DELIVERABLEs/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DELIVERABLE dELIVERABLE = db.DELIVERABLES.Find(id);
            if (dELIVERABLE == null)
            {
                return HttpNotFound();
            }
            return View(dELIVERABLE);
        }

        // POST: DELIVERABLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DELIVERABLE dELIVERABLE = db.DELIVERABLES.Find(id);
            db.DELIVERABLES.Remove(dELIVERABLE);
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
