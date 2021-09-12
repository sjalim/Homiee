using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class Bank
    {
        [Key]
        public int BankID { get; set; }
        public int BankAccountHolderID { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string BankRoutingNumber { get; set; }
        public string BankingNumber { get; set; }

        public virtual User User { get; set; }
    }
}