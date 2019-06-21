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
    public class EventsController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();

        // GET: Admin/Events
        public ActionResult Index()
        {
            var events = ctx.Events;
                //Include(@ => @.Location).Include(@ => @.receptionPackage);
            return View(events.ToList());
        }

        // GET: Admin/Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = ctx.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Admin/Events/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(ctx.EventLocations, "Id", "Name");
            ViewBag.Id = new SelectList(ctx.ReceptionPackages, "Id", "Name");
            return View();
        }

        // POST: Admin/Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Description,Time,Duration,Participants")] Event @event)
        {
            if (ModelState.IsValid)
            {
                ctx.Events.Add(@event);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(ctx.EventLocations, "Id", "Name", @event.Id);
            ViewBag.Id = new SelectList(ctx.ReceptionPackages, "Id", "Name", @event.Id);
            return View(@event);
        }

        // GET: Admin/Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = ctx.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(ctx.EventLocations, "Id", "Name", @event.Id);
            ViewBag.Id = new SelectList(ctx.ReceptionPackages, "Id", "Name", @event.Id);
            return View(@event);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Description,Time,Duration,Participants")] Event @event)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(@event).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(ctx.EventLocations, "Id", "Name", @event.Id);
            ViewBag.Id = new SelectList(ctx.ReceptionPackages, "Id", "Name", @event.Id);
            return View(@event);
        }

        // GET: Admin/Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = ctx.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = ctx.Events.Find(id);
            ctx.Events.Remove(@event);
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
