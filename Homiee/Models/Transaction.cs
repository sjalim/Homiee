using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        public int TransactionType { get; set; }

        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public DateTime TransactionTime { get;set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public string TxID { get; set; }
    }
}