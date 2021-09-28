using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class SigninHotel
    {

        [Required]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }
        [Required]
        [Display(Name = "Manager Name")]
        public string HotelManager { get; set; }
        [Required]
        [Display(Name = "Manager Phone")]
        public string HoteManagerPhone { get; set; }
        [Required]
        [Display(Name = "Hotel Lanline")]
        public string HotelLanLine { get; set; }
        [Required]
        [Display(Name = "Hotel Email")]
        public string HotelEmail { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string HotelPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string HotelConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Trade License No")]
        public string HotelTradeLicenseNo { get; set; }
    }
}