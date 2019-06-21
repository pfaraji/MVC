using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventHandlingApp.Models;

namespace EventHandlingApp.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: Admin/Customers
        public ActionResult Index()
        {
            var Customers = ctx.Customers.Include(c => c.applicationUser);
            return View(Customers.ToList());
        }

        // GET: Admin/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = ctx.People.Find(id) as Customer;
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Admin/Customers/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Admin/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Family,NationalCode,CustId,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                ctx.People.Add(customer);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", customer.Id);
            return View(customer);
        }

        // GET: Admin/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = ctx.People.Find(id) as Customer;
            if (customer == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", customer.Id);
            return View(customer);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Family,NationalCode,CustId,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(customer).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email", customer.Id);
            return View(customer);
        }

        // GET: Admin/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = ctx.People.Find(id) as Customer;
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Admin/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = ctx.People.Find(id) as Customer;
            ctx.People.Remove(customer);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
