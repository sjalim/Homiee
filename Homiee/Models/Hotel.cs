using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Hotel
    {
        [Key]
        public int HotelID { get; set; }
        public string HotelManager { get; set; }
        public string HotelName { get; set; }
        public string HoteManagerPhone { get; set; }
        public string HotelLanLine { get; set; }
        public string HotelEmail { get; set; }
        public string HotelPassword { get; set; }
        public string HotelTradeLicenseNo { get; set; }
        public byte[] HotelPictures { get; set; }
        public Nullable<System.DateTime> HotelRegistrationData { get; set; }
        public int HotelAddressID { get; set; }

        public virtual ICollection<GuestsToHotelsReview> GuestsToHotelsReviews { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}