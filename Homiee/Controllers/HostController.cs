using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    
    
    }


}