using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class User
    {
     
        [Key]
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public int UserTypeID { get; set; }
        public Nullable<System.DateTime> UserRegistrationDate { get; set; }
        public byte[] UserProfilePicture { get; set; }

        public string AddressCountry { get; set; }
        public string AddressDivision { get; set; }
        public string AddressCity { get; set; }
        public string AddressArea { get; set; }
        public string AddressExtension { get; set; }




    }
}