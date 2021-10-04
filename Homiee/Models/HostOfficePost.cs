using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostOfficePost
    {

        public int HostOfficePostID { get; set; }


        public double SpaceSize { get; set; }

        public double Price { get; set; }


        public int PaymentType { get; set; }

        public string Offer { get; set; }

        public string AddFile { get; set; }

        public string RoomCaption { get; set; }
       

        public virtual User User { get; set; }
    }
}