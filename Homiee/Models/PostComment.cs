using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class PostComment
    {

        [Key]
        public int PostCommentID { get; set; }
        public int PostID { get; set; }
        public int PostCommenterID { get; set; }
        public string PostComment1 { get; set; }

        public virtual Post Post { get; set; }
    }
}