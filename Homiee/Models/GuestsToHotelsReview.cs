using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class GuestsToHotelsReview
    {

        [Key]
        public int ReviewID { get; set; }
        public int ReviewerID { get; set; }
        public int ReviewedID { get; set; }
        public string ReviewDescription { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual User User { get; set; }
    }
}