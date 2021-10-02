using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostingInfo
    {
        [Key]
        public int HostingInfoID { get; set; }

        [Required(ErrorMessage ="Selecting Room type required")]
        [DisplayName("Rooms")]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "Number of Rooms required")]
        public int NumberRooms { get; set; }

        [Required(ErrorMessage = "Number of Kitchens required")]
        public int NumberKitchens { get; set; }

        [Required(ErrorMessage = "Number of Washrooms required")]
        public int NumberWashrooms { get; set; }

        [Required(ErrorMessage = "Number of Balconys required")]
        public int NumberBalconys { get; set; }

        [Required(ErrorMessage = "Additional Features required")]
        public string AdditionalFeaturess { get; set; }

        [Required(ErrorMessage = "Country Names required")]
        public string CountryNames { get; set; }

        [Required(ErrorMessage = "Street Names required")]
        public string StreetNames { get; set; }

        [Required(ErrorMessage = "City Names required")]
        public string CityNames { get; set; }

        [Required(ErrorMessage = "State Names required")]
        public string StateNames { get; set; }

        [Required(ErrorMessage = "Postal Code required")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Hosting rules required")]
        public string HostingRules { get; set; }

        [Required(ErrorMessage = "Minimum Stay required")]
        public int MinimumStay { get; set; }

        [Required(ErrorMessage = "Maximum Stay required")]
        public int MaximumStay { get; set; }

        [Required(ErrorMessage = "Prices required")]
        public decimal Prices { get; set; }

        [Required(ErrorMessage = "Offers required")]
        public string Offers { get; set; }

        [Required(ErrorMessage = "Room Caption required")]
        public string RoomsCaption { get; set; }
        // public byte[] AddFile { get; set; }

        public virtual User UserID { get; set; }
    }

    
}