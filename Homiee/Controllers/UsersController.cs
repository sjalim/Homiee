﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Security;
using System.Web.Mvc;
using Homiee.Models;
using System.Web;
using System.Diagnostics;

using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.IO;

namespace Homiee.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static int GUEST_CATEGORY = 0;
        public static int HOST_CATEGORY = 1;
        public static int HOTEL_CATEGORY = 2;
        // GET: Users
        public ActionResult Index()
        {
            return View("Index","Home");
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

                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var user = Session["UserID"];
            var typeId = Convert.ToInt32(Session["UserType"]);

            if (user != null)
            {
                if (typeId == GUEST_CATEGORY)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (typeId == HOST_CATEGORY)
                {
                    return RedirectToAction("Index", "Host");
                }
                else
                {
                    return RedirectToAction("Index", "Hotel");
                }
            }

            return View();


        }
        [HttpPost]
        public ActionResult Login(LoginUser user)
        {

            User logedInUser = null;

            if (ModelState.IsValid)
            {

                Debug.WriteLine("User category" + user.UserCategory);

                String encryptedPass = Encryptdata(user.Password);
                String category = user.UserCategory.ToString();

                //Response.Cookies["UserID"].Value = logedInUser.UserID.ToString();
                //Response.Cookies["UserEmail"].Value = logedInUser.UserEmail.ToString();


                if (category.Equals("Host") || category.Equals("Guest"))
                {
                    logedInUser = db.Users.Where(a => a.UserEmail.Equals(user.Email)
               &&
               a.UserPassword.Equals(encryptedPass)).FirstOrDefault();

                    if (logedInUser != null)
                    {

                        Session["UserID"] = logedInUser.UserID.ToString();
                        Session["UserEmail"] = logedInUser.UserEmail.ToString();

                        if (category.Equals("Host"))
                        {
                            Debug.WriteLine("check host");
                            if (logedInUser.UserTypeID == HOST_CATEGORY)
                            {

                                Session["UserType"] = HOST_CATEGORY;
                                Debug.WriteLine("user passed data:" + logedInUser.UserEmail);
                                return RedirectToAction("Init", "Host", logedInUser );
                            }
                            else
                            {
                                ViewBag.errorMsgLogin = "Your not HOST! Category invalid";
                            }
                        }
                        else if (category.Equals("Guest"))
                        {
                            Debug.WriteLine("check guest");
                            if (logedInUser.UserTypeID == GUEST_CATEGORY)
                            {

                                Session["UserType"] = GUEST_CATEGORY;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewBag.errorMsgLogin = "Your not Guest! Category invalid";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.errorMsgLogin = "User not found!";
                    }
                }
                else
                {
                    Hotel logedInHotel = db.Hotels.Where(a => a.HotelEmail.Equals(user.Email)
                   &&
                   a.HotelPassword.Equals(encryptedPass)).FirstOrDefault();

                    Debug.WriteLine("check hotel");
                    if (logedInHotel != null)
                    {

                        Session["UserID"] = logedInHotel.HotelID.ToString();
                        Session["UserEmail"] = logedInHotel.HotelEmail.ToString();
                        Session["UserType"] = HOTEL_CATEGORY;

                        return RedirectToAction("Index", "Hotel");
                    }
                    else
                    {
                        ViewBag.errorMsgLogin = "User not found!";
                    }

                }
            }
            return View();
        }

     
        public ActionResult LogOut()
        {

            Session.Abandon();

            FormsAuthentication.SignOut();
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


        [HttpGet]
        public ActionResult Profile()
        {

            int userId = Convert.ToInt32(Session["UserID"]);
            ProfileViewModel viewModel = new ProfileViewModel();
            //Debug.WriteLine("check the id:" + userId);
            if (userId != null)
            {

                //    Debug.WriteLine(" Images: " + user.UserProfilePicture);

                viewModel.User = db.Users.Where(a => a.UserID.Equals(userId)).FirstOrDefault();
                viewModel.GetNotifications = db.Notifications.Select(t => t)
                    .Where(a => a.Reserver.UserID == userId)
                    .Where(b => b.NotificationType == HomeController.HOST_NOTIFY_USER).ToList();
                viewModel.transactions = db.Transactions.Select(t => t).Where(a => a.SenderID == userId).ToList();

                return View(viewModel);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Profile(FormCollection data)
        {
            User user = null;
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    int Id = Convert.ToInt32(Session["UserID"]);

                    user = db.Users.Where(a => a.UserID == Id).FirstOrDefault();

                    user.UserFirstName = data["UserFirstName"];
                    user.UserLastName = data["UserLastName"];
                    user.UserPhone = data["UserPhone"];
                    user.UserEmail = data["UserEmail"];
                    user.AddressArea = data["AddressArea"];
                    user.AddressCity = data["AddressCity"];
                    user.AddressCountry = data["AddressCountry"];
                    user.AddressDivision = data["AddressDivision"];
                    user.AddressExtension = data["AddressExtension"];


                    Debug.WriteLine("first name=" + user.UserFirstName);
                    Debug.WriteLine("last name=" + user.UserLastName);

                    //db.Entry(user).State = EntityState.Modified;

                    Debug.WriteLine("at success");
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                Debug.WriteLine("not null");
                return RedirectToAction("Profile", "Users");
            }
            Debug.WriteLine("is null");
            return RedirectToAction("Profile", "Users");


        }

        [HttpPost]
        public ActionResult UploadProfileImage(HttpPostedFileBase UserProfilePicture)
        {

            int Id = Convert.ToInt32(Session["UserID"]);

            User user = db.Users.Where(a => a.UserID == Id).FirstOrDefault();

            string extension = Path.GetExtension(UserProfilePicture.FileName);

            string fileName = "DP" + DateTime.Now.ToString("yymmssfff") + extension;

            string path = Path.Combine(Server.MapPath("~/Images/"), fileName);

            Debug.WriteLine("  at image:" + user.UserFirstName + " file name:" + UserProfilePicture.FileName + " path:" + path);



            Debug.WriteLine("Extension:" + extension);
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {
                Debug.WriteLine("at jpg");
                if (UserProfilePicture.ContentLength <= 4194304)
                {

                    Debug.WriteLine("at saveas");
                    user.UserProfilePicture = "~/Images/" + fileName;
                    UserProfilePicture.SaveAs(path);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            return RedirectToAction("Profile");
        }


    }
}
