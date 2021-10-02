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
    public class HostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static int HOST_CATEGORY = 1;
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostInfo hostinfo = db.HostInfoes.Find(id);
            if(hostinfo==null)
            {
                return HttpNotFound();
            }
            return View(hostinfo);
        }

        [HttpGet]
        public ActionResult AddAPlace()
        {
            Debug.WriteLine("hmmmm");
            return View();
        }

        [HttpPost]
        public ActionResult AddAPlace(HostInfo hostinfo)
        {
            HostInfo newHostInfo = new HostInfo();
            Debug.WriteLine("" + hostinfo.Room + "room");
            if (ModelState.IsValid)
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
                newHostInfo.AddFile = hostinfo.AddFile;

                db.HostInfoes.Add(newHostInfo);
                db.SaveChanges();
                return RedirectToAction("Index","Host");
            }

            return View();
            /*db.HostInfoes.Add(hostinfo);
            db.SaveChanges();
            return RedirectToAction("Index", "Host");*/

        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult MyPlaces()
        {
            /*HostInfo obj = new HostInfo();
            obj.MyPlacesModelObject = new List<HostInfo>();
            return View(obj);*/
            //return View();
            List<HostInfo> hostinfoes = db.HostInfoes.ToList<HostInfo>();
            return View(hostinfoes);
        }

        public ActionResult Reviews()
        {
            List<GuestsToHostsReview> gueststohostsreview = db.GuestsToHostsReviews.ToList<GuestsToHostsReview>();
            return View(gueststohostsreview);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostInfo hostinfo = db.HostInfoes.Find(id);
            if (hostinfo == null)
            {
                return HttpNotFound();
            }
            return View(hostinfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostInfoID,Room,NumRooms,NumKitchens,NumWash,NumBalconys,AdditionalFeatures,CountryName,StreetName,CityName,StateName,PostCode,HostRules,MinStay,MaxStay,Price,Offer,RoomCaption,AddFile")] HostInfo hostinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPlaces");
            }
            return View(hostinfo);
        }

        [HttpPost]
        public ActionResult SignUp(FormCollection user)
        {
            Debug.WriteLine("check the host");
            var chek = user["UserEmail"];
            Debug.WriteLine("check the host " + chek);
            User newUser = new User();

            if(ModelState.IsValid)
            {

                Debug.WriteLine("check the host data entry");
                newUser.UserFirstName = user["UserFirstName"];
                newUser.UserLastName = user["UserLastName"];
                newUser.UserEmail = user["UserEmail"];
                newUser.UserPhone = user["UserPhone"];
                newUser.UserPassword = UsersController.Encryptdata(user["UserPassword"]);
                newUser.UserRegistrationDate = DateTime.Now;
                newUser.UserTypeID = HOST_CATEGORY;
                newUser.AddressCountry = user["AddressCountry"];
                newUser.AddressDivision = user["AddressDivision"];
                newUser.AddressCity = user["AddressCity"];
                newUser.AddressArea = user["AddressArea"];
                newUser.AddressExtension = user["AddressExtension"];
                db.Users.Add(newUser);
                db.SaveChanges();
            }
           return RedirectToAction("Login","Users");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostInfo hostinfo = db.HostInfoes.Find(id);
            if (hostinfo == null)
            {
                return HttpNotFound();
            }
            return View(hostinfo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostInfo hostinfo = db.HostInfoes.Find(id);
            db.HostInfoes.Remove(hostinfo);
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