using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string HotelPictures { get; set; }
        public DateTime? HotelRegistrationDate { get; set; }
        public int? HotelAddressID { get; set; }
        [ForeignKey("HotelAddressID")]
        public virtual HotelAddress HotelAddress { get; set; }


        public virtual ICollection<GuestsToHotelsReview> GuestsToHotelsReviews { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

    }
}