using Homiee.Models;
using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpGet]
        public ActionResult AddPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPlace(HostInfo hostinfo)
        {
            if(ModelState.IsValid)
            {
                db.HostInfos.Add(hostinfo);
            }
            return RedirectToAction("Index", "HostLanding");

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