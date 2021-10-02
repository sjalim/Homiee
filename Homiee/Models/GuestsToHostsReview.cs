using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class GuestsToHostsReview
    {

        [Key]
        public int ReviewID { get; set; }

        [Required(ErrorMessage = "Reviewer ID required")]
        [Display(Name = "Reviewer ID")]
        public int ReviewerID { get; set; }

        [Required(ErrorMessage = "Reviewed ID required")]
        [Display(Name = "Reviewed ID")]
        public int ReviewedID { get; set; }

        [Required(ErrorMessage = "Review Description required")]
        [Display(Name = "Review Description")]
        public string ReviewDescription { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}