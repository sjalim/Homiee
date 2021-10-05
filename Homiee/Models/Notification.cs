using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Notification
    {
        [Key]
        public int NotificaitonID { get; set; }

        public string NotifyText { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? NotifyTime { get; set; }
        
        public int SeenStatus { get; set; }
        
        public int NotificationType { get; set; }
        public virtual User Reserver { get; set; }
        public virtual HostPostInfo Post { get; set; }
        public virtual User Renter { get; set; }

        public virtual Reservation Reservation { get; set; }

        
    }
}