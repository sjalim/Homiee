using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class NotificationViewModel
    {

       public List<Notification> GetNotifications { get; set; }
        public NewNotification GetNewNotification { get; set; }


    }
}