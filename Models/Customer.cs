using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewspaperSubscription.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerCredentials = new HashSet<CustomerCredential>();
            Subscriptions = new HashSet<Subscription>();
        }

        [Display(Name = "Id")]
        public int Customerid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 15 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Customername { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 10,
        ErrorMessage = "Address should be minimum 3 characters and a maximum of 50 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Customeraddress { get; set; } = null!;
        [Display(Name = "City")]
        public int? Customercity { get; set; }

        public virtual City? CustomercityNavigation { get; set; }
        public virtual ICollection<CustomerCredential> CustomerCredentials { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
