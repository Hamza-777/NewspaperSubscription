using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Subscriptions = new HashSet<Subscription>();
            VendorCredentials = new HashSet<VendorCredential>();
        }

        public int Vendorid { get; set; }
        public string Vendorname { get; set; } = null!;
        public int? Vendorcity { get; set; }

        public virtual City? VendorcityNavigation { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<VendorCredential> VendorCredentials { get; set; }
    }
}
