﻿using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Core.Models.Owner
{
    public class CreateOwnerModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(OwnerPhoneNumberMaxLength,
     MinimumLength = OwnerPhoneNumberMinLength,
     ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        
        public string PhoneNumber { get; set; } = null!;
       

    }
}
