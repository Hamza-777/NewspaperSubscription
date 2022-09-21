using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCredentials = new HashSet<CustomerCredential>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int Customerid { get; set; }
        public string Customername { get; set; } = null!;
        public string Customeraddress { get; set; } = null!;
        public int? Customercity { get; set; }

        public virtual City? CustomercityNavigation { get; set; }
        public virtual ICollection<CustomerCredential> CustomerCredentials { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
