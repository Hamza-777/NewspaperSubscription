﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewspaperSubscription.Models
{
    public partial class CustomerCredential
    {
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(15, MinimumLength = 3,
        ErrorMessage = "UserName should be minimum 3 characters and a maximum of 15 characters")]
        [DataType(DataType.Text)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "Customer")]
        public int? Customer { get; set; }

        public virtual Customer? CustomerNavigation { get; set; }
    }
}
