using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewspaperSubscription.Models
{
    public partial class Subscription
    {
        [Display(Name = "Id")]
        public int Subscriptionid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(7, MinimumLength = 6,
        ErrorMessage = "Type should be one of these: Weekly, Monthly or Yearly")]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string Subscriptiontype { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        public DateTime Subscriptionstartdate { get; set; }

        [Display(Name = "Customer")]
        public int? Customer { get; set; }

        [Display(Name = "Newspaper")]
        public int? Newspaper { get; set; }

        [Display(Name = "Vendor")]
        public int? Vendor { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
        public virtual NewsPaper? NewspaperNavigation { get; set; }
        public virtual Vendor? VendorNavigation { get; set; }
    }
}
