using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Homiee.Controllers
{
    public class HostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static int HOST_CATEGORY = 1;

        User user;
        public ActionResult Init(User user)
        {
            if (Session["UserId"] != null)
            {
                this.user = user;
                Debug.WriteLine("user passed data:" + user.UserEmail);
                return RedirectToAction("Index", "Host");
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            if (Session["UserId"] != null)
            {

                NewNotification newNotification = new NewNotification();
                newNotification.active = true;

                return View(newNotification);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Details(int? id)
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

        public ActionResult DetailsOffice(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostOfficePost hostofficepost = db.HostOfficePosts.Find(id);
            if(hostofficepost == null)
            {
                return HttpNotFound();
            }
            return View(hostofficepost);
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
                newHostPostInfo.User = this.user;

                db.HostPostInfoes.Add(newHostPostInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "Host");
            }

            return View();


        }

        public ActionResult GuestPost()
        {
            NewNotification newNotification = new NewNotification();
            newNotification.active = true;

            return View(newNotification);
        }

        [HttpPost]
        public ActionResult GuestPostData(FormCollection data, HttpPostedFileBase AddFile)
        {


            var userId = Convert.ToInt32(Session["UserID"]);
            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();
            HostPostInfo newHostPostInfo = new HostPostInfo();
            if (data != null)
            {
                if (ModelState.IsValid)
                {

                    newHostPostInfo.Room = 0;
                    newHostPostInfo.Title = data["Title"];
                    newHostPostInfo.NumRooms = Convert.ToInt32(data["NumRooms"]);
                    newHostPostInfo.NumKitchens = Convert.ToInt32(data["NumKitchens"]);
                    newHostPostInfo.NumWash = Convert.ToInt32(data["NumWash"]);
                    newHostPostInfo.NumBalconys = Convert.ToInt32(data["NumBalconys"]);
                    newHostPostInfo.AdditionalFeatures = data["AdditionalFeatures"];
                    newHostPostInfo.CountryName = data["CountryName"];
                    newHostPostInfo.StreetName = data["StreetName"];
                    newHostPostInfo.StateName = data["StateName"];
                    newHostPostInfo.CityName = data["CityName"];
                    newHostPostInfo.PostCode = Convert.ToInt32(data["PostCode"]);
                    newHostPostInfo.HostRules = data["HostRules"];
                    newHostPostInfo.MinStay = Convert.ToInt32(data["MinStay"]);
                    newHostPostInfo.MaxStay = Convert.ToInt32(data["MaxStay"]);
                    newHostPostInfo.Price = Convert.ToDecimal(data["Price"]);
                    newHostPostInfo.PaymentType = Convert.ToInt32(data["PaymentType"]);
                    newHostPostInfo.Offer = data["Offer"];
                    newHostPostInfo.RoomCaption = data["RoomCaption"];
                    newHostPostInfo.User = user;

                    string extension = Path.GetExtension(AddFile.FileName);

                    string fileName = DateTime.Now.ToString("yymmssfff") + "guestPost" + extension;

                    string path = Path.Combine(Server.MapPath("~/Images/Host/Post/Guest/"), fileName);


                    Debug.WriteLine("Extension:" + extension);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        Debug.WriteLine("at jpg");
                        if (AddFile.ContentLength <= 4194304)
                        {

                            Debug.WriteLine("at saveas");
                            newHostPostInfo.AddFile = "~/Images/Host/Post/Guest/" + fileName;
                            AddFile.SaveAs(path);

                        }
                    }

                    db.HostPostInfoes.Add(newHostPostInfo);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }

                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult ApartmentPost()
        {
            NewNotification newNotification = new NewNotification();
            newNotification.active = true;

            return View(newNotification);
        }
        public ActionResult ApartmentPostData(FormCollection data, HttpPostedFileBase AddFile)
        {


            var userId = Convert.ToInt32(Session["UserID"]);
            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();

            HostPostInfo newHostPostInfo = new HostPostInfo();
            if (data != null)
            {
                if (ModelState.IsValid)
                {

                    newHostPostInfo.Room = 1;
                    newHostPostInfo.Title = data["Title"];
                    newHostPostInfo.NumRooms = Convert.ToInt32(data["NumRooms"]);
                    newHostPostInfo.NumKitchens = Convert.ToInt32(data["NumKitchens"]);
                    newHostPostInfo.NumWash = Convert.ToInt32(data["NumWash"]);
                    newHostPostInfo.NumBalconys = Convert.ToInt32(data["NumBalconys"]);
                    newHostPostInfo.AdditionalFeatures = data["AdditionalFeatures"];
                    newHostPostInfo.CountryName = data["CountryName"];
                    newHostPostInfo.StreetName = data["StreetName"];
                    newHostPostInfo.StateName = data["StateName"];
                    newHostPostInfo.CityName = data["CityName"];
                    newHostPostInfo.PostCode = Convert.ToInt32(data["PostCode"]);
                    newHostPostInfo.HostRules = data["HostRules"];
                    newHostPostInfo.MinStay = Convert.ToInt32(data["MinStay"]);
                    newHostPostInfo.MaxStay = Convert.ToInt32(data["MaxStay"]);
                    newHostPostInfo.Price = Convert.ToInt32(data["Price"]);
                    newHostPostInfo.PaymentType = Convert.ToInt32(data["PaymentType"]);
                    newHostPostInfo.Offer = data["Offer"];
                    newHostPostInfo.RoomCaption = data["RoomCaption"];
                    newHostPostInfo.User = user;
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
                            newHostPostInfo.AddFile = "~/Images/Host/Post/Apartment/" + fileName;
                            AddFile.SaveAs(path);

                        }
                    }
                    ModelState.Clear();
                    db.HostPostInfoes.Add(newHostPostInfo);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult OfficePost()
        {
            NewNotification newNotification = new NewNotification();
            newNotification.active = true;

            return View(newNotification);
        }

        [HttpPost]
        public ActionResult OfficePostData(FormCollection data, HttpPostedFileBase AddFile)
        {

            var userId = Convert.ToInt32(Session["UserID"]);
            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();
            HostOfficePost hostOfficePost = new HostOfficePost();
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    hostOfficePost.Title = data["Title"];
                    hostOfficePost.SpaceSize = Convert.ToDouble(data["SpaceSize"]);
                    hostOfficePost.NumRooms = Convert.ToInt32(data["NumRooms"]);
                    
                    hostOfficePost.NumWash = Convert.ToInt32(data["NumWash"]);
                    hostOfficePost.NumBalconys = Convert.ToInt32(data["NumBalconys"]);
                    hostOfficePost.AdditionalFeatures = data["AdditionalFeatures"];
                    hostOfficePost.CountryName = data["CountryName"];
                    hostOfficePost.StreetName = data["StreetName"];
                    hostOfficePost.StateName = data["StateName"];
                    hostOfficePost.CityName = data["CityName"];
                    hostOfficePost.PostCode = Convert.ToInt32(data["PostCode"]);
                    hostOfficePost.HostRules = data["HostRules"];
              
                    hostOfficePost.Price = Convert.ToInt32(data["Price"]);
                    hostOfficePost.PaymentType = Convert.ToInt32(data["PaymentType"]);
                    hostOfficePost.Offer = data["Offer"];
                    hostOfficePost.RoomCaption = data["RoomCaption"];
                    hostOfficePost.User = user;


                    string extension = Path.GetExtension(AddFile.FileName);
                    string fileName = DateTime.Now.ToString("yymmssfff") + "officePost" + extension;

                    string path = Path.Combine(Server.MapPath("~/Images/Host/Post/Office/"), fileName);


                    Debug.WriteLine("Extension:" + extension);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        Debug.WriteLine("at jpg");
                        if (AddFile.ContentLength <= 4194304)
                        {

                            Debug.WriteLine("at saveas");
                            hostOfficePost.AddFile = "~/Images/Host/Post/Office/" + fileName;
                            AddFile.SaveAs(path);
                        }
                    }
                    ModelState.Clear();
                    db.HostOfficePosts.Add(hostOfficePost);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult AllPost()
        {

            AllPostViewModel viewModel = new AllPostViewModel();
            var userId = Convert.ToInt32(Session["UserID"]);
            viewModel.hostPostInfos = (List<HostPostInfo>)db.HostPostInfoes.Select(t => t).Where(a => a.User.UserID == userId).ToList();
            viewModel.hostOfficePosts = (List<HostOfficePost>)db.HostOfficePosts.Select(t => t).Where(a => a.User.UserID == userId).ToList();
            viewModel.GetNewNotification = new NewNotification()
            {
                active = false
            };
            Debug.WriteLine("User ID :" + userId);

            foreach (var x in viewModel.hostPostInfos)
            {
                Debug.WriteLine(x.Title);
            }


            return View(viewModel);
        }


        public ActionResult Transaction()
        {
            NewNotification newNotification = new NewNotification();
            newNotification.active = true;

            return View(newNotification);

        }

        public ActionResult Notification()
        {
            var userId = Convert.ToInt32(Session["UserID"]);

            NotificationViewModel viewModel = new NotificationViewModel();

            viewModel.GetNotifications = db.Notifications.Select(t => t).Where(a => a.Renter.UserID == userId).Where(b => b.NotificationType == HomeController.USER_NOTIFY_HOST).ToList();

            viewModel.GetNewNotification = new NewNotification()
            {
                active = true
            };

            return View(viewModel);
        }





        public ActionResult Profile()
        {
            var userId = Convert.ToInt32(Session["UserID"]);
            HostProfileViewModel viewModel = new HostProfileViewModel();


            viewModel.mobileBankings = db.MobileBankings.Select(t => t).Where(a => a.MobileBankingAccountHolderID == userId).ToList();
            viewModel.GetNewNotification = new NewNotification()
            {
                active = false
            };

            return View(viewModel);
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
            HostReviewsViewModel viewModel = new HostReviewsViewModel();



            viewModel.guestsToHostsReviews = db.GuestsToHostsReviews.ToList<GuestsToHostsReview>();

            viewModel.GetNewNotification = new NewNotification()
            {
                active = false
            };

            return View(viewModel);
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

            if (ModelState.IsValid)
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
            return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        public ActionResult MobileBanking(FormCollection data)
        {

            MobileBanking newAccount = new MobileBanking();

            var userId = Convert.ToInt32(Session["UserID"]);

            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();


            if (data != null)
            {
                newAccount.MobileBankingAccountHolderID = userId;
                newAccount.MobileBankingAccountNumber = data["AccountNumber"];
                newAccount.MobileBankingAccountType = Convert.ToInt32(data["Type"]);
                newAccount.User = user;

                db.MobileBankings.Add(newAccount);
                db.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ReservationAccept(int? id)
        {

            Debug.WriteLine("Notificaition id: " + id);
            Notification newNotification = new Notification();
            if (id != null)
            {
                var notification = db.Notifications.Select(t => t).Where(a => a.NotificaitonID == id).FirstOrDefault();

                notification.Reservation.Status = HomeController.RESERVATION_APPROVED;

                newNotification.NotifyText = "Your reservation has been Accept";
                newNotification.NotifyTime = DateTime.Now;
                newNotification.Post = notification.Post;
                newNotification.SeenStatus = HomeController.NOTIFICATION_UNSEEN;
                newNotification.Reserver = notification.Reserver;
                newNotification.Renter = notification.Renter;
                newNotification.Reservation = notification.Reservation;
                newNotification.NotificationType = HomeController.HOST_NOTIFY_USER;

                db.Entry(notification).State = EntityState.Modified;
                db.Notifications.Add(newNotification);
                db.SaveChanges();

            }
            return RedirectToAction("Notification");
        }

        public ActionResult ReservationCancel(int? id)
        {
            Debug.WriteLine("Notificaition id: " + id);


            if (id != null)
            {
                var notification = db.Notifications.Select(t => t).Where(a => a.NotificaitonID == id).FirstOrDefault();

                if (notification.Reservation.Status != HomeController.RESERVATION_UNAPPROVED)
                {
                    notification.Reservation.Status = HomeController.RESERVATION_UNAPPROVED;

                     
                }

                db.Entry(notification).State = EntityState.Modified;
                db.SaveChanges();

            }
            return RedirectToAction("Notification");
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