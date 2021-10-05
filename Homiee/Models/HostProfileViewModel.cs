using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostProfileViewModel
    {

     public List<MobileBanking> mobileBankings { get; set; }

    public NewNotification GetNewNotification { get; set; }
    }
}