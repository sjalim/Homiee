using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Chat
    {

        [Key]
        public int ChatID { get; set; }
        public Nullable<int> ChatSenderID { get; set; }
        public Nullable<int> ChatReceiverID { get; set; }
        public string ChatMessage { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}