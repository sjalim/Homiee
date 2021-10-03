using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostPostInfo
    {
        [Key]
        public int HostPostInfoID { get; set; }

        [Required(ErrorMessage = "Selecting Room type required")]
        [Display(Name = "Rental Type")]
        public string Room { get; set; }

        [Required(ErrorMessage = "Number of Rooms required")]
        [Display(Name = "Number of Rooms")]
        public int NumRooms { get; set; }

        [Required(ErrorMessage = "Number of Kitchens required")]
        [Display(Name = "Number of Kitchens")]
        public int NumKitchens { get; set; }

        [Required(ErrorMessage = "Number of Washrooms required")]
        [Display(Name = "Number of Washrooms")]
        public int NumWash { get; set; }

        [Required(ErrorMessage = "Number of Balconys required")]
        [Display(Name = "Number of Balconys")]
        public int NumBalconys { get; set; }

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

        [Required(ErrorMessage = "Host Rules required")]
        [Display(Name = "Host Rules")]
        public string HostRules { get; set; }

        [Required(ErrorMessage = "Minimum Stay required")]
        [Display(Name = "Minimum Stay")]
        public int MinStay { get; set; }

        [Required(ErrorMessage = "Maximum Stay required")]
        [Display(Name = "Maximum Stay")]
        public int MaxStay { get; set; }

        [Required(ErrorMessage = "Prices required")]
        [Display(Name = "Cost Per Day(BDT)")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Offers required")]
        [Display(Name = "Offers")]
        public string Offer { get; set; }

        [Required(ErrorMessage = "Adding File required")]
        [Display(Name = "Added Files")]
        public string AddFile { get; set; }

        [Required(ErrorMessage = "Room Caption required")]
        [Display(Name = "Room Caption")]
        public string RoomCaption { get; set; }

        public virtual User UserID { get; set; }

        /*public List<HostInfo> MyPlacesModelObject { get; set; }*/

    }
}