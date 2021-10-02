using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HotelInfo
    {
        [Key]
        public int HotelInfoID { get; set; }

        [Required(ErrorMessage = "Hotel Name Required")]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Hotel Trade Licence Number required")]
        [Display(Name = "Trade Licence No.")]
        public string HotelTradeLicence { get; set; }

        [Required(ErrorMessage = "Hotel Room Type required")]
        [Display(Name = "Hotel Room Type")]
        public string HotelRoomType { get; set; }

        [Required(ErrorMessage = "Number of Beds required")]
        [Display(Name = "Number of beds")]
        public int NumBed { get; set; }

        [Required(ErrorMessage = "Number of Washroom required")]
        [Display(Name = "Number of Washroom")]
        public int NumWash { get; set; }

        [Required(ErrorMessage = "Additional Features required")]
        [Display(Name = "Additional Features")]
        public string AdditionalFeatures { get; set; }

        [Required(ErrorMessage = "Country Names required")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Street Names required")]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "City Names required")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "State Names required")]
        [Display(Name = "State Name")]
        public string StateName { get; set; }

        [Required(ErrorMessage = "Postal Code required")]
        [Display(Name = "Post Code")]
        public int PostCode { get; set; }

        [Required(ErrorMessage = "Hotel Rules required")]
        [Display(Name = "Hotel Rules")]
        public string HotelRules { get; set; }

    

        [Required(ErrorMessage = "Prices required")]
        [Display(Name = "Cost Per Day(BDT)")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Offers required")]
        [Display(Name = "Offers")]
        public string Offer { get; set; }

        [Required(ErrorMessage = "Adding File required")]
        [Display(Name = "Added Files")]
        public string AddFile { get; set; }

        [Required(ErrorMessage = "Hotel Room Caption required")]
        [Display(Name = "Hotel Room Caption")]
        public string HotelRoomCaption { get; set; }

        public virtual User UserID { get; set; }
    }
}