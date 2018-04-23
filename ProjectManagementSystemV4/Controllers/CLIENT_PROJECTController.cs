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
    public class CLIENT_PROJECTController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: CLIENT_PROJECT
        public ActionResult Index()
        {
            var cLIENT_PROJECT = db.CLIENT_PROJECT.Include(c => c.CLIENT).Include(c => c.PROJECT);
            return View(cLIENT_PROJECT.ToList());
        }

        // GET: CLIENT_PROJECT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_PROJECT cLIENT_PROJECT = db.CLIENT_PROJECT.Find(id);
            if (cLIENT_PROJECT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT_PROJECT);
        }

        // GET: CLIENT_PROJECT/Create
        public ActionResult Create()
        {
            ViewBag.Client_ID = new SelectList(db.CLIENTs, "Client_ID", "Name");
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name");
            return View();
        }

        // POST: CLIENT_PROJECT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_project_ID,Client_ID,Project_ID,Last_update,Last_update_by,Payment")] CLIENT_PROJECT cLIENT_PROJECT)
        {
            if (ModelState.IsValid)
            {
                db.CLIENT_PROJECT.Add(cLIENT_PROJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client_ID = new SelectList(db.CLIENTs, "Client_ID", "Name", cLIENT_PROJECT.Client_ID);
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", cLIENT_PROJECT.Project_ID);
            return View(cLIENT_PROJECT);
        }

        // GET: CLIENT_PROJECT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_PROJECT cLIENT_PROJECT = db.CLIENT_PROJECT.Find(id);
            if (cLIENT_PROJECT == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client_ID = new SelectList(db.CLIENTs, "Client_ID", "Name", cLIENT_PROJECT.Client_ID);
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", cLIENT_PROJECT.Project_ID);
            return View(cLIENT_PROJECT);
        }

        // POST: CLIENT_PROJECT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_project_ID,Client_ID,Project_ID,Last_update,Last_update_by,Payment")] CLIENT_PROJECT cLIENT_PROJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENT_PROJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client_ID = new SelectList(db.CLIENTs, "Client_ID", "Name", cLIENT_PROJECT.Client_ID);
            ViewBag.Project_ID = new SelectList(db.PROJECTs, "Project_ID", "Name", cLIENT_PROJECT.Project_ID);
            return View(cLIENT_PROJECT);
        }

        // GET: CLIENT_PROJECT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_PROJECT cLIENT_PROJECT = db.CLIENT_PROJECT.Find(id);
            if (cLIENT_PROJECT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT_PROJECT);
        }

        // POST: CLIENT_PROJECT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENT_PROJECT cLIENT_PROJECT = db.CLIENT_PROJECT.Find(id);
            db.CLIENT_PROJECT.Remove(cLIENT_PROJECT);
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
