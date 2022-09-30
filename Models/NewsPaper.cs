using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewspaperSubscription.Models
{
    public partial class NewsPaper
    {
        public NewsPaper()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        [Display(Name = "Id")]
        public int Newspaperid { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 15 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Newspapername { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public float Newspaperprice { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Weekly Subscription Price")]
        public float Weeklysubscription { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Monthly Subscription Price")]
        public float Monthlysubscription { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Yearly Subscription Price")]
        public float Yearlysubscription { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Language")]
        public string Newspaperlanguage { get; set; } = null!;

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
