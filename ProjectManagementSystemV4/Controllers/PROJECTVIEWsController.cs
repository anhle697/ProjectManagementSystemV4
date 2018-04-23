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
    public class PROJECTVIEWsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: PROJECTVIEWs
        public ActionResult Index()
        {
            var pROJECTs = db.PROJECTs.Include(p => p.DEPARTMENT).Include(p => p.EMPLOYEE);
            return View(pROJECTs.ToList());
        }

        // GET: PROJECTVIEWs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROJECT pROJECT = db.PROJECTs.Find(id);
            if (pROJECT == null)
            {
                return HttpNotFound();
            }
            return View(pROJECT);
        }

    
    }
}
