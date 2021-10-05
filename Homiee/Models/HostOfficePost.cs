using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostOfficePost
    {

        public int HostOfficePostID { get; set; }

        public string Title { get; set; }
        public int NumRooms { get; set; }
        public double SpaceSize { get; set; }

        public int NumWash { get; set; }
        public int NumBalconys { get; set; }
        public string AdditionalFeatures { get; set; }
        public string CountryName { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int PostCode { get; set; }
        public string HostRules { get; set; }
        public double Price { get; set; }
        public int PaymentType { get; set; }
        public string Offer { get; set; }
        public string AddFile { get; set; }
        public string RoomCaption { get; set; }
        public virtual User User { get; set; }
    }
}