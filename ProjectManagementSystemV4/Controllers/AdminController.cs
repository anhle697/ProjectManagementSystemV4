using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagementSystemV4.Models;

namespace ProjectManagementSystemV4.Controllers
{
    public class AdminController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
        
}