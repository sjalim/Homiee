using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Reservation
    {

        [Key]
        public int ReservationID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CheckIn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CheckOut { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReserveTime { get; set; }

        public int Status { get; set; }

        public virtual HostPostInfo Post { get; set; }
        public virtual User Reserver { get; set; }

        public virtual User Renter { get; set; }
    }
}