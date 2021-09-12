using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class MobileBanking
    {
        [Key]
        public int MobileBankingID { get; set; }
        public int MobileBankingAccountHolderID { get; set; }
        public string MobileBankingAccountNumber { get; set; }
        public string MobileBankingAccountType { get; set; }

        public virtual User User { get; set; }
    }
}