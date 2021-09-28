using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class LoginUser
    {


        [Required]
        [Display(Name = "Email")]
        public Category UserCategory { get; set; }

        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }




    public enum Category
    {
       Guest,
       Host,
       Hotel
    }
}