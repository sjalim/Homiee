using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostsToGuestsReview
    {
        [Key]
        public int ReviewID { get; set; }
        public int ReviewerID { get; set; }
        public int ReviewedID { get; set; }
        public string ReviewDescription { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}