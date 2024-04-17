using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Performance;
using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Core.Models.Phone
{
    public class PhoneAddModel : IPhoneModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneBrandMaximumLength,
           MinimumLength = PhoneBrandMinimumLenght,
           ErrorMessage = LengthMessage)]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneModelMaxLength,
            MinimumLength = PhoneModelMinLength,
            ErrorMessage = LengthMessage)]
        public string Model { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal),
            PhonePriceMinimum,
            PhonePriceMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price per month must be a positive number and less than {2} leva")]
        [Display(Name = "Phone price")]
        public decimal Price { get; set; }
        [Display(Name = "Image URL")]
        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Category")]
        public int CategoryId { get; set;}

        public IEnumerable<PhoneCategoriesServiceModel> Categories { get; set; } = new List<PhoneCategoriesServiceModel>();

        public PerformanceDetailsFormModel Performances { get; set; } = null!;

        public IEnumerable<CommentServiceModel> Comments { get; set; } = new List<CommentServiceModel>();

    }
}
