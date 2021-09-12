using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Post
    {

        public int PostID { get; set; }
        public int PostOwnerID { get; set; }
        public string PostOwnerType { get; set; }
        public string PostDescription { get; set; }
        public byte[] PostImages { get; set; }
        public Nullable<System.DateTime> PostDate { get; set; }

        public virtual ICollection<PostComment> PostComments { get; set; }
        public virtual User User { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}