using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProjectManagementSystemV4.Models;

namespace ProjectManagementSystemV4.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: EMPLOYEEs
        [HttpGet]
        public ActionResult Index()
        {
            var eMPLOYEEs = db.EMPLOYEEs.Include(e => e.EMPLOYEE_DELIVERABLE);
            return View(eMPLOYEEs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string FirstName, string EmpType, string LastName, string Email, EMPLOYEE emp)
        {
            var eMPLOYEEs = db.EMPLOYEEs.ToList().Where(p => p.F_name.StartsWith(FirstName) && p.Employee_type.StartsWith(EmpType)
            && p.L_name.StartsWith(LastName) && p.Email_address.Contains(Email));
            return View(eMPLOYEEs);
        }

        // GET: EMPLOYEEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public ActionResult Create()
        {
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE_DELIVERABLE, "Employee_deliverable_ID", "Last_update_by");
            ViewBag.Employee_ID = new SelectList(db.User_login, "Employee_ID", "Username");

            var getTypeList = db.EMPLOYEE_TYPES.ToList();
            SelectList list = new SelectList(getTypeList, "TypeID", "Employee_Type");
            ViewBag.employeetype = list;
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,F_name,Employee_type,Hourly_rate,M_name,L_name,Last_update,Last_update_by,Email_address")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                var user = (new ApplicationDbContext()).Users.FirstOrDefault(s => s.Id == userId);
                MailMessage message = new System.Net.Mail.MailMessage();
                string fromEmail = "umapmsproject@gmail.com";
                string password = "Staple10";
                string toEmail = "anhle697@aim.com";
                message.From = new MailAddress(fromEmail);
                message.To.Add(toEmail);
                message.Subject = "A new employee has been created.";
                message.Body = String.Format("An employeed named {0} {1} has been created in the EMPLOYEE table by manager of username {2}.", eMPLOYEE.F_name, eMPLOYEE.L_name, user.UserName);
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, password);

                    smtpClient.Send(message.From.ToString(), message.To.ToString(), message.Subject, message.Body);
                }
                db.EMPLOYEEs.Add(eMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var getTypeList = db.EMPLOYEE_TYPES.ToList();
            SelectList list = new SelectList(getTypeList, "TypeID", "Employee_Type");
            ViewBag.employeetype = list;
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE_DELIVERABLE, "Employee_deliverable_ID", "Last_update_by", eMPLOYEE.Employee_ID);
            ViewBag.Employee_ID = new SelectList(db.User_login, "Employee_ID", "Username", eMPLOYEE.Employee_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }

            var getTypeList = db.EMPLOYEE_TYPES.ToList();
            SelectList list = new SelectList(getTypeList, "TypeID", "Employee_Type");
            ViewBag.employeetype = list;
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE_DELIVERABLE, "Employee_deliverable_ID", "Last_update_by", eMPLOYEE.Employee_ID);
            ViewBag.Employee_ID = new SelectList(db.User_login, "Employee_ID", "Username", eMPLOYEE.Employee_ID);
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,F_name,Employee_type,Hourly_rate,M_name,L_name,Last_update,Last_update_by,Email_address")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var getTypeList = db.EMPLOYEE_TYPES.ToList();
            SelectList list = new SelectList(getTypeList, "TypeID", "Employee_Type");
            ViewBag.employeetype = list;
            ViewBag.Employee_ID = new SelectList(db.EMPLOYEE_DELIVERABLE, "Employee_deliverable_ID", "Last_update_by", eMPLOYEE.Employee_ID);
            ViewBag.Employee_ID = new SelectList(db.User_login, "Employee_ID", "Username", eMPLOYEE.Employee_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            db.EMPLOYEEs.Remove(eMPLOYEE);
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
