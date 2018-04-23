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
    public class DEPARTMENTsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: DEPARTMENTs
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.DEPARTMENTs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string DepartmentName, DEPARTMENT dEPARTMENT)
        {
            var DEPARTMENTs = db.DEPARTMENTs.ToList().Where(p => p.Name.StartsWith(DepartmentName));
            return View(DEPARTMENTs);
        }
        // GET: DEPARTMENTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DEPARTMENTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Dept_ID,Last_update,Last_update_by")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENTs.Add(dEPARTMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Dept_ID,Last_update,Last_update_by")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            if (dEPARTMENT == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTMENT dEPARTMENT = db.DEPARTMENTs.Find(id);
            db.DEPARTMENTs.Remove(dEPARTMENT);
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
