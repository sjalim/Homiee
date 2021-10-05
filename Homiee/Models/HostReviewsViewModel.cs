using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homiee.Models
{
    public class HostReviewsViewModel
    {
        public List<GuestsToHostsReview> guestsToHostsReviews { get; set; }
        public NewNotification GetNewNotification { get; set; }
    }
}