using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

    }


}