using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Homiee.Models;

namespace Homiee.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static int GUEST_CATEGORY = 0;

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }


        // GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,UserEmail,UserPassword,UserFirstName,UserLastName,UserPhone,UserTypeID,UserAddressID,UserRegistrationData,UserProfilePicture,AddressCountry,AddressDivision,AddressCity,AddressArea,AddressExtension")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult SignUp()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SigninUser user)
        {
            User newUser = new User();

            if (ModelState.IsValid)
            {
                newUser.UserFirstName = user.UserFirstName;
                newUser.UserLastName = user.UserLastName;
                newUser.UserEmail = user.UserEmail;
                newUser.UserPhone = user.UserPhone;
                newUser.UserPassword = Encryptdata(user.UserPassword);
                newUser.UserRegistrationDate = DateTime.Now;
                newUser.UserTypeID = GUEST_CATEGORY;
                newUser.AddressCountry = user.AddressCountry;
                newUser.AddressDivision = user.AddressDivision;
                newUser.AddressCity = user.AddressCity;
                newUser.AddressArea = user.AddressArea;
                newUser.AddressExtension = user.AddressExtension;
                db.Users.Add(newUser);
                db.SaveChanges();

                return RedirectToAction("Login","Account");
            }

            return View();

            
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();        
        }
        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            return RedirectToAction("Index", "Home");

        }



        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}
