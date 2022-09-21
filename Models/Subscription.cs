using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class Subscription
    {
        public int Subscriptionid { get; set; }
        public string Subscriptiontype { get; set; } = null!;
        public DateTime Subscriptionstartdate { get; set; }
        public int? Customer { get; set; }
        public int? Newspaper { get; set; }
        public int? Vendor { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
        public virtual NewsPaper? NewspaperNavigation { get; set; }
        public virtual Vendor? VendorNavigation { get; set; }
    }
}
