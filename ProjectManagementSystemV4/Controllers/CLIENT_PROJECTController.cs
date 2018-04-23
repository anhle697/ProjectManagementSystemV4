using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProjectManagementSystemV4.Models;

namespace ProjectManagementSystemV4.Controllers
{
    public class CLIENT_PROJECTController : Controller
    {
        private ProjectManagementSystemEntities db = new ProjectManagementSystemEntities();

        // GET: CLIENT_PROJECT
        [HttpGet]
        public ActionResult Index()
        {
            var cLIENT_PROJECT = db.CLIENT_PROJECT.Include(c => c.CLIENT).Include(c => c.PROJECT);
            return View(cLIENT_PROJECT.ToList());
        }

        [HttpPost]
        public ActionResult Index(string ClientName, string ProjectName, CLIENT_PROJECT Cp)
        {
            var cLIENT_PROJECT = db.CLIENT_PROJECT.ToList().Where(P => P.CLIENT.Name.StartsWith(ClientName) && P.PROJECT.Name.StartsWith(ProjectName));
            return View(cLIENT_PROJECT);
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
                var clientname = db.CLIENTs.FirstOrDefault(c => c.Client_ID == cLIENT_PROJECT.Client_ID);
                var projectname = db.PROJECTs.FirstOrDefault(c => c.Project_ID == cLIENT_PROJECT.Project_ID);
                MailMessage message = new System.Net.Mail.MailMessage();
                string fromEmail = "umapmsproject@gmail.com";
                string password = "Staple10";
                string toEmail = "anhle697@aim.com";
                message.From = new MailAddress(fromEmail);
                message.To.Add(toEmail);
                message.Subject = "A payment has been added for a client.";
                message.Body = String.Format("A new payment of ${0} has been saved to the client-project association table for client {1} for project named {2}.", cLIENT_PROJECT.Payment, clientname.Name,projectname.Name);
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, password);

                    smtpClient.Send(message.From.ToString(), message.To.ToString(), message.Subject, message.Body);
                }
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
