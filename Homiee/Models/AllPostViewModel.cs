using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class AllPostViewModel
    {

        public List<HostOfficePost> hostOfficePosts { get; set; }

        public List<HostPostInfo> hostPostInfos { get; set; }
    }
}