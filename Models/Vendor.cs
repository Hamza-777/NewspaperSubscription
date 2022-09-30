using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewspaperSubscription.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Subscriptions = new HashSet<Subscription>();
            VendorCredentials = new HashSet<VendorCredential>();
        }

        [Display(Name = "Id")]
        public int Vendorid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 15 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Vendorname { get; set; } = null!;
        [Display(Name = "City")]
        public int? Vendorcity { get; set; }

        public virtual City? VendorcityNavigation { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<VendorCredential> VendorCredentials { get; set; }
    }
}
