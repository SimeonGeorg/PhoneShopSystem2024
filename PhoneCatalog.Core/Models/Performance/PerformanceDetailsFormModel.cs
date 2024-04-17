using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Core.Models.Performance
{
    public class PerformanceDetailsFormModel
    {
       
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone RAM memory")]
        [StringLength(PhonePerformanceMaxLength
            ,MinimumLength = PhonePerformanceMinLength
            ,ErrorMessage = LengthMessage)]
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
