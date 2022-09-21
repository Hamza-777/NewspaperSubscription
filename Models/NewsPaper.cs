using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class NewsPaper
    {
        public NewsPaper()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int Newspaperid { get; set; }
        public string Newspapername { get; set; } = null!;
        public float Newspaperprice { get; set; }
        public float Weeklysubscription { get; set; }
        public float Monthlysubscription { get; set; }
        public float Yearlysubscription { get; set; }
        public string Newspaperlanguage { get; set; } = null!;

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
