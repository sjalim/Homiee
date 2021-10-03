using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homiee.Controllers
{
    public class HotelController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hotel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAPlace(HotelInfo hotelinfo)
        {
            db.HotelInfoes.Add(hotelinfo);
            db.SaveChanges();
            return RedirectToAction("Index", "Hotel");
        }

        public ActionResult MyPlaces()
        {
            List<HotelInfo> hotelinfoes = db.HotelInfoes.ToList<HotelInfo>();
            return View(hotelinfoes);
        }

        public ActionResult Reviews()
        {
            List<GuestsToHotelsReview> gueststohotelsreview = db.GuestsToHotelsReviews.ToList<GuestsToHotelsReview>();
            return View(gueststohotelsreview);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelInfo hotelinfo = db.HotelInfoes.Find(id);
            if (hotelinfo == null)
            {
                return HttpNotFound();
            }
            return View(hotelinfo);
        }

        public ActionResult SignUp(FormCollection hotel)
        {
            Debug.WriteLine("check at hotel signup");
            Debug.WriteLine("check at hotel signup" +hotel["HotelName"]);
            Hotel newHotel = new Hotel();
            if(ModelState.IsValid)
            {
                Debug.WriteLine("check at hotel in");
                newHotel.HotelName = hotel["HotelName"];
                newHotel.HotelManager = hotel["HotelManager"];
                newHotel.HotelEmail = hotel["HotelEmail"];
                newHotel.HotelPassword = UsersController.Encryptdata(hotel["HotelPassword"]);
                newHotel.HotelRegistrationDate = DateTime.Now;
                newHotel.HoteManagerPhone = hotel["HoteManagerPhone"];
                newHotel.HotelTradeLicenseNo = hotel["HotelTradeLicenseNo"];
                newHotel.HotelLanLine = hotel["HotelLanLine"];
                db.Hotels.Add(newHotel);
                db.SaveChanges();
            }
            return RedirectToAction("Login", "Users");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelInfo hotelinfo = db.HotelInfoes.Find(id);
            if (hotelinfo == null)
            {
                return HttpNotFound();
            }
            return View(hotelinfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelInfoID,HotelName,HotelTradeLicence,HotelRoomType,NumBed,NumWash,AdditionalFeatures,CountryName,StreetName,CityName,StateName,PostCode,HotelRules,Cost,Offer,Addfile,HotelRoomCaption")] HotelInfo hotelinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPlaces");
            }
            return View(hotelinfo);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelInfo hotelinfo = db.HotelInfoes.Find(id);
            if(hotelinfo == null)
            {
                return HttpNotFound();
            }
            return View(hotelinfo);
            
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelInfo Hotelinfo = db.HotelInfoes.Find(id);
            db.HotelInfoes.Remove(Hotelinfo);
            db.SaveChanges();
            return RedirectToAction("MyPlaces");
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