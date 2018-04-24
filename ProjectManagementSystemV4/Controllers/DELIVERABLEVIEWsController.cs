using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystemV4.Models;

namespace ProjectManagementSystemV4.Views
{
    public class DELIVERABLEVIEWsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: DELIVERABLEVIEWs
        public ActionResult Index()
        {
            var dELIVERABLES = db.DELIVERABLES.Include(d => d.PROJECT);
            return View(dELIVERABLES.ToList());
        }

        // GET: DELIVERABLEVIEWs/Details/5
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
