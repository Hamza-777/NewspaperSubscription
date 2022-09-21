using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class City
    {
        public City()
        {
            Customers = new HashSet<Customer>();
            Vendors = new HashSet<Vendor>();
        }

        public int Cityid { get; set; }
        public string Cityname { get; set; } = null!;
        public string Citystate { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
