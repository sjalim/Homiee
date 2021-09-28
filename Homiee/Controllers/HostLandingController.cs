using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homiee.Controllers
{
    public class HostLandingController : Controller
    {
        // GET: HostLanding
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.HostInfoes.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult AddPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlace(HostInfo hostinfo)
        {
            HostInfo newHostInfo = new HostInfo();
            Debug.WriteLine(""+hostinfo.Room+"room");
            if(ModelState.IsValid)
            {
                newHostInfo.Room = hostinfo.Room;
                newHostInfo.NumRooms = hostinfo.NumRooms;
                newHostInfo.NumKitchens = hostinfo.NumKitchens;
                newHostInfo.NumWash = hostinfo.NumWash;
                newHostInfo.NumBalconys = hostinfo.NumBalconys;
                newHostInfo.AdditionalFeatures = hostinfo.AdditionalFeatures;
                newHostInfo.CountryName = hostinfo.CountryName;
                newHostInfo.StreetName = hostinfo.StreetName;
                newHostInfo.CityName = hostinfo.CityName;
                newHostInfo.StateName = hostinfo.StateName;
                newHostInfo.PostCode = hostinfo.PostCode;
                newHostInfo.HostRules = hostinfo.HostRules;
                newHostInfo.MinStay = hostinfo.MinStay;
                newHostInfo.MaxStay = hostinfo.MaxStay;
                newHostInfo.Price = hostinfo.Price;
                newHostInfo.Offer = hostinfo.Offer;
                newHostInfo.RoomCaption = hostinfo.RoomCaption;

                db.HostInfoes.Add(newHostInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "HostLanding");
            }
            return View();

        }


        public ActionResult Preview()
        {
            return View();
        }

        public ActionResult Reviews()
        {
            return View();
        }

    }
}