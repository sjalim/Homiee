using Homiee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homiee.Controllers
{
    public class HomeController : Controller
    {

        public static int USER_NOTIFY_HOST = 0;
        public static int HOST_NOTIFY_USER = 1;

        public static int NOTIFICATION_SEEN = 1;
        public static int NOTIFICATION_UNSEEN = 0;


        public static int RESERVATION_APPROVED = 1;
        public static int RESERVATION_UNAPPROVED = 0;

        public static int BKASH_TRANSACTION = 0;
        public static int NOGOD_TRANSACTION = 1;



        private ApplicationDbContext db = new ApplicationDbContext();

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

            var apartmentData = db.HostPostInfoes.Select(t => t).ToList();



            return View(apartmentData);
        }

        public ActionResult ApartmentDetails(int? id)
        {
            var userId = Convert.ToInt32(Session["UserID"]);

            if (id != null)
            {

                Debug.WriteLine("apartmentID :" + id);

                ApartmentDetailsViewModel viewModel = new ApartmentDetailsViewModel();

                viewModel.GetHostPostInfo = db.HostPostInfoes.Select(t => t).Where(a => a.HostPostInfoID == id).FirstOrDefault();

                viewModel.GetReservation = db.Reservations.Select(t => t).Where(a => a.Post.HostPostInfoID == id).Where(b => b.Reserver.UserID == userId).FirstOrDefault();
                return View(viewModel);
            }
            return RedirectToAction("Apartment");
        }

        [HttpPost]
        public ActionResult ReserveRequestApartment(FormCollection data)
        {

            Reservation reservation = new Reservation();
            Notification notification = new Notification();


            var userId = Convert.ToInt32(Session["UserID"]);
            User user = db.Users.Where(a => a.UserID == userId).FirstOrDefault();
            if (data != null)
            {
                var postId = Convert.ToInt32(data["Id"]);

                if (postId != null)
                {
                    var apartmentData = (HostPostInfo)db.HostPostInfoes.Select(t => t).Where(a => a.HostPostInfoID == userId).FirstOrDefault();


                    reservation.CheckIn = DateTime.Parse(data["CheckIn"]);
                    reservation.CheckOut = DateTime.Parse(data["CheckOut"]);
                    reservation.Post = apartmentData;
                    reservation.Reserver = user;
                    reservation.Renter = apartmentData.User;
                    reservation.Status = 0;//pending 
                    reservation.ReserveTime = DateTime.Now;

                    Debug.WriteLine("datetime: " + reservation.CheckIn + " " + reservation.CheckOut);

                    //notification
                    notification.NotifyText = user.UserFirstName + " " + user.UserLastName + " is wanted to reserve your place!";
                    notification.NotifyTime = DateTime.Now;
                    notification.Post = apartmentData;
                    notification.SeenStatus = HomeController.NOTIFICATION_UNSEEN;
                    notification.Reserver = user;
                    notification.Renter = apartmentData.User;
                    notification.Reservation = reservation;
                    notification.NotificationType = USER_NOTIFY_HOST;

                    db.Notifications.Add(notification);
                    db.Reservations.Add(reservation);

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
                Debug.WriteLine("post Id : " + data["Id"]);
                return RedirectToAction("ApartmentDetails", new { id = postId });

            }
            return RedirectToAction("Apartment");


        }

        [HttpPost]
        public ActionResult PaymentRequest(FormCollection data)
        {
            Transaction transaction = new Transaction();
            Notification notification = new Notification();
            Debug.WriteLine("at payment ");
            if(data!=null)
            {

                var postId = Convert.ToInt32(data["PostID"]);
                HostPostInfo post = db.HostPostInfoes.Where(a => a.HostPostInfoID == postId).FirstOrDefault();
                var receiverId = Convert.ToInt32(data["ReceiverID"]);
                var senderId = Convert.ToInt32(data["SenderID"]);
                var reservationId = Convert.ToInt32(data["ReservationId"]);

                transaction.TransactionType = Convert.ToInt32(data["Type"]);
                transaction.ReceiverAccountNumber =data["AccountNumberTo"];
                transaction.SenderAccountNumber = data["AccountNumberFrom"];
                transaction.ReceiverID = Convert.ToInt32(data["ReceiverID"]);
                transaction.SenderID = Convert.ToInt32(data["SenderID"]);
                transaction.TransactionTime = DateTime.Now;
                transaction.TxID = data["TxId"];

                notification.NotificationType = USER_NOTIFY_HOST;
                notification.NotifyText = "Money sent please check";
                notification.NotifyTime = DateTime.Now;
                notification.Post = post;
                notification.Renter = db.Users.Where(t => t.UserID == receiverId).FirstOrDefault();
                notification.Reserver = db.Users.Where(t => t.UserID == senderId).FirstOrDefault();
                notification.Reservation = db.Reservations.Where(t => t.ReservationID == reservationId).FirstOrDefault();
                notification.SeenStatus = HomeController.NOTIFICATION_UNSEEN;

                db.Transactions.Add(transaction);
                db.Notifications.Add(notification);
                db.SaveChanges();

            }
            
            
            return RedirectToAction("Index");
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