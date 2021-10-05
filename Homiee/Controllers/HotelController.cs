using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
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

    

        public ActionResult AddAPlace()
        {
            return View();
        }
        public ActionResult AddAPlaceData(FormCollection data, HttpPostedFileBase AddFile)
        {


            var userId = Convert.ToInt32(Session["UserID"]);
            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();

            HotelInfo newHotelInfo = new HotelInfo();
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    newHotelInfo.HotelName = data["HotelName"];
                    newHotelInfo.HotelTradeLicence = (data["HotelTradeLicence"]);
                    newHotelInfo.HotelRoomType = (data["HotelRoomType"]);
                    newHotelInfo.NumBed = Convert.ToInt32(data["NumBed"]);
                    newHotelInfo.NumWash = Convert.ToInt32(data["NumWash"]);
                    newHotelInfo.AdditionalFeatures = data["AdditionalFeatures"];
                    newHotelInfo.CountryName = data["CountryName"];
                    newHotelInfo.StreetName = data["StreetName"];
                    newHotelInfo.StateName = data["StateName"];
                    newHotelInfo.CityName = data["CityName"];
                    newHotelInfo.PostCode = Convert.ToInt32(data["PostCode"]);
                    newHotelInfo.HotelRules = data["HotelRules"];
                   
                    newHotelInfo.Cost = Convert.ToInt32(data["Cost"]);
                    
                    newHotelInfo.Offer = data["Offer"];
                    newHotelInfo.HotelRoomCaption = data["HotelRoomCaption"];

                    string extension = Path.GetExtension(AddFile.FileName);

                    string fileName = DateTime.Now.ToString("yymmssfff") + "apartmentPost" + extension;

                    string path = Path.Combine(Server.MapPath("~/Images/Host/Post/Apartment/"), fileName);


                    Debug.WriteLine("Extension:" + extension);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        Debug.WriteLine("at jpg");
                        if (AddFile.ContentLength <= 4194304)
                        {

                            Debug.WriteLine("at saveas");
                            newHotelInfo.AddFile = "~/Images/Hotel/Post/Places/" + fileName;
                            AddFile.SaveAs(path);

                        }
                    }
                    ModelState.Clear();
                    db.HotelInfoes.Add(newHotelInfo);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
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