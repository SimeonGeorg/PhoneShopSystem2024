using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Infrastructure.Data.Models
{
    [Comment("Phone category")]
    public class CategoryType
    {
        [Comment("Category identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Category name")]
        [Required]
        [StringLength(PhoneCategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        public List<Phone> Phones { get; set; } = new List<Phone>();

    }
}
