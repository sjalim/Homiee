using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HotelAddress
    {

        [Key]
        public int HotelAddressID { get; set; }
        public string AddressCountry { get; set; }
        public string AddressDivision { get; set; }
        public string AddressCity { get; set; }
        public string AddressArea { get; set; }
        public string AddressExtension { get; set; }

    }
}