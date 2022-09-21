using System;
using System.Collections.Generic;

namespace NewspaperSubscription.Models
{
    public partial class CustomerCredential
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? Customer { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
    }
}
