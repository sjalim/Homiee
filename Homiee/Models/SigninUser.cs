using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class SigninUser
    {


        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string UserConfirmPassword { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }
        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string UserPhone { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string AddressCountry { get; set; }
        [Display(Name = "Division")]
        public string AddressDivision { get; set; }
        [Required]
        [Display(Name = "City")]
        public string AddressCity { get; set; }
        [Required]
        [Display(Name = "Area")]
        public string AddressArea { get; set; }
        [Required]
        [Display(Name = "Address Extension")]
        public string AddressExtension { get; set; }
    }
}