using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homiee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Explore()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Host()
        {
            ViewBag.Message = "Your contact page.";

            SignInModelHosts regModel = new SignInModelHosts();
            SigninUser Host = new SigninUser();
            SigninHotel Hotel = new SigninHotel();

            regModel.Host = Host;
            regModel.Hotel = Hotel;


            return View(regModel);
        }

        public ActionResult Apartment()
        {

            return View();
        }

        public ActionResult Office()
        {

            return View();
        }

        public ActionResult Hotel()
        {
            return View();

        }

        public ActionResult PartyPlace()
        {
            return View();
        }
        public ActionResult CommunityCenter()
        {

            return View();
        }

    }

}