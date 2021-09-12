using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Rating
    {

        public int RatingID { get; set; }
        public Nullable<int> RatingHolderID { get; set; }
        public Nullable<int> RatingHonesty { get; set; }
        public Nullable<int> RatingKindness { get; set; }
        public Nullable<int> RatingServices { get; set; }

        public virtual User User { get; set; }
    }
}