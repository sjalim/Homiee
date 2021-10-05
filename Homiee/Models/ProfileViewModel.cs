
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class ProfileViewModel
    {

       public List<Notification> GetNotifications { get; set; }

       public User User { get; set; }


        public List<Transaction> transactions { get; set; }
    }
}