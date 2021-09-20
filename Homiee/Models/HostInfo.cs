using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostInfo
    {
        [Key]
        public int HostInfoID { get; set; }
        public int Room { get; set; }
        public int NumRooms { get; set; }
        public int NumKitchens { get; set; }
        public int NumWash { get; set; }
        public int NumBalconys { get; set; }
        public string AdditionalFeatures { get; set; }

        public string CountryName { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public int PostCode { get; set; }

        public string HostRules { get; set; }
        public int MinStay { get; set; }
        public int MaxStay { get; set; }
        public double Price { get; set; }
        public string Offer { get; set; }
        public string RoomCaption { get; set; }
       // public byte[] AddFile { get; set; }

        public virtual User UserID { get; set; }

    }
}