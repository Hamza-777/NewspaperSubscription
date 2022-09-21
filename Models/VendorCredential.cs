using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class VendorCredential
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? Vendor { get; set; }

        public virtual Vendor? VendorNavigation { get; set; }
    }
}
