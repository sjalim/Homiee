using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class UserComment
    {

        [Key]
        public int UserCommentID { get; set; }
        public int UserCommenterID { get; set; }
        public int UserCommentOnID { get; set; }
        public string UserComment1 { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}