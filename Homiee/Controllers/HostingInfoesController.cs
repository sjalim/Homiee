using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Homiee.Models;

namespace Homiee.Controllers
{
    public class HostingInfoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HostingInfoes
        public ActionResult Index()
        {
            return View(db.hostinginfo.ToList());
        }

        // GET: HostingInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingInfo hostingInfo = db.hostinginfo.Find(id);
            if (hostingInfo == null)
            {
                return HttpNotFound();
            }
            return View(hostingInfo);
        }

        // GET: HostingInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostingInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HostingInfoID,Rooms,NumberRooms,NumberKitchens,NumberWashrooms,NumberBalconys,AdditionalFeaturess,CountryNames,StreetNames,CityNames,StateNames,PostalCode,HostingRules,MinimumStay,MaximumStay,Prices,Offers,RoomsCaption")] HostingInfo hostingInfo)
        {
            if (ModelState.IsValid)
            {
                db.hostinginfo.Add(hostingInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hostingInfo);
        }

        // GET: HostingInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingInfo hostingInfo = db.hostinginfo.Find(id);
            if (hostingInfo == null)
            {
                return HttpNotFound();
            }
            return View(hostingInfo);
        }

        // POST: HostingInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostingInfoID,Rooms,NumberRooms,NumberKitchens,NumberWashrooms,NumberBalconys,AdditionalFeaturess,CountryNames,StreetNames,CityNames,StateNames,PostalCode,HostingRules,MinimumStay,MaximumStay,Prices,Offers,RoomsCaption")] HostingInfo hostingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostingInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hostingInfo);
        }

        // GET: HostingInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingInfo hostingInfo = db.hostinginfo.Find(id);
            if (hostingInfo == null)
            {
                return HttpNotFound();
            }
            return View(hostingInfo);
        }

        // POST: HostingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostingInfo hostingInfo = db.hostinginfo.Find(id);
            db.hostinginfo.Remove(hostingInfo);
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
