using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Core.Models.Performance
{
    public class PerformanceEditFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Performance identifier")]
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone RAM memory")]
        [StringLength(PhonePerformanceMaxLength
         , MinimumLength = PhonePerformanceMinLength
         , ErrorMessage = LengthMessage)]
        public string Ram { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone processor")]
        [StringLength(PhonePerformanceMaxLength,
            MinimumLength = PhonePerformanceMinLength,
            ErrorMessage = LengthMessage)]
        public string Processor { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone storage")]
        [StringLength(PhonePerformanceMaxLength,
            MinimumLength = PhonePerformanceMinLength,
            ErrorMessage = LengthMessage)]
        public string Storage { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone camera pixels")]
        [StringLength(PhonePerformanceMaxLength,
            MinimumLength = PhonePerformanceMinLength,
            ErrorMessage = LengthMessage)]
        public string CameraPxl { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone battery")]
        [StringLength(PhonePerformanceMaxLength,
            MinimumLength = PhonePerformanceMinLength,
            ErrorMessage = LengthMessage)]
        public string Battery { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone identifier")]
        public int PhoneId { get; set; }
    }
}
