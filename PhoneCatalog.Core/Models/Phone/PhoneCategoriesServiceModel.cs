using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Core.Models.Phone
{
    public class PhoneCategoriesServiceModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneCategoryNameMaxLength,
            MinimumLength = PhoneCategoryNameMinLength,
            ErrorMessage = RequiredMessage)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = string.Empty;
        
    }
}
