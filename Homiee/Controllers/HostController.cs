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
            HostPostInfo hostpostinfo = db.HostPostInfoes.Find(id);
            if(hostpostinfo==null)
            {
                return HttpNotFound();
            }
            return View(hostpostinfo);
        }

        [HttpGet]
        public ActionResult AddAPlace()
        {
            Debug.WriteLine("hmmmm");
            return View();
        }

        [HttpPost]
        public ActionResult AddAPlace(HostPostInfo hostpostinfo)
        {
            HostPostInfo newHostPostInfo = new HostPostInfo();
            Debug.WriteLine("" + hostpostinfo.Room + "room");
            if (ModelState.IsValid)
            {
                newHostPostInfo.Room = hostpostinfo.Room;


                int roomcheck;

                if(hostpostinfo.Room == "1")
                {
                    newHostPostInfo.Room = "Apartment";
                }

                else if (hostpostinfo.Room == "2")
                {
                    newHostPostInfo.Room = "Office";
                }

                else if (hostpostinfo.Room == "3")
                {
                    newHostPostInfo.Room = "Party Place";
                }

                else if (hostpostinfo.Room == "4")
                {
                    newHostPostInfo.Room = "Community Center";
                }

                else if (hostpostinfo.Room == "5")
                {
                    newHostPostInfo.Room = "Guest";
                }

                newHostPostInfo.NumRooms = hostpostinfo.NumRooms;
                newHostPostInfo.NumKitchens = hostpostinfo.NumKitchens;
                newHostPostInfo.NumWash = hostpostinfo.NumWash;
                newHostPostInfo.NumBalconys = hostpostinfo.NumBalconys;
                newHostPostInfo.AdditionalFeatures = hostpostinfo.AdditionalFeatures;
                newHostPostInfo.CountryName = hostpostinfo.CountryName;
                newHostPostInfo.StreetName = hostpostinfo.StreetName;
                newHostPostInfo.CityName = hostpostinfo.CityName;
                newHostPostInfo.StateName = hostpostinfo.StateName;
                newHostPostInfo.PostCode = hostpostinfo.PostCode;
                newHostPostInfo.HostRules = hostpostinfo.HostRules;
                newHostPostInfo.MinStay = hostpostinfo.MinStay;
                newHostPostInfo.MaxStay = hostpostinfo.MaxStay;
                newHostPostInfo.Price = hostpostinfo.Price;
                newHostPostInfo.Offer = hostpostinfo.Offer;
                newHostPostInfo.RoomCaption = hostpostinfo.RoomCaption;
                newHostPostInfo.AddFile = hostpostinfo.AddFile;

                db.HostPostInfoes.Add(newHostPostInfo);
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
            List<HostPostInfo> hostpostinfoes = db.HostPostInfoes.ToList<HostPostInfo>();
            return View(hostpostinfoes);
        }

        public ActionResult Reviews()
        {
            List<GuestsToHostsReview> gueststohostsreview = db.GuestsToHostsReviews.ToList<GuestsToHostsReview>();
            return View(gueststohostsreview);
        }

        public ActionResult ParticularReviews(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*HostPostInfo hostpostinfo = db.HostPostInfoes.Find(id);
            if (hostpostinfo == null)
            {
                return HttpNotFound();
            }
            return View(hostpostinfo);*/
            ParticularHostRoomReview phrr = db.ParticularHostRoomReviews.Find(id);
            if(phrr==null)
            {
                return HttpNotFound();
            }
            return View(phrr);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostPostInfo hostpostinfo = db.HostPostInfoes.Find(id);
            if (hostpostinfo == null)
            {
                return HttpNotFound();
            }
            return View(hostpostinfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostPostInfoID,Room,NumRooms,NumKitchens,NumWash,NumBalconys,AdditionalFeatures,CountryName,StreetName,CityName,StateName,PostCode,HostRules,MinStay,MaxStay,Price,Offer,RoomCaption,AddFile")] HostPostInfo hostpostinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostpostinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyPlaces");
            }
            return View(hostpostinfo);
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
            HostPostInfo hostpostinfo = db.HostPostInfoes.Find(id);
            if (hostpostinfo == null)
            {
                return HttpNotFound();
            }
            return View(hostpostinfo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HostPostInfo hostpostinfo = db.HostPostInfoes.Find(id);
            db.HostPostInfoes.Remove(hostpostinfo);
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