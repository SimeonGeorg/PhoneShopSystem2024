using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Infrastructure.Data.Models
{
    [Comment("Phone to publish")]
    public class Phone
    {
        [Comment("Phone identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Phone brand")]
        [Required]
        [StringLength(PhoneBrandMaximumLength)]
        public string Brand { get; set; } = string.Empty;
        [Comment("Phone model")]
        [StringLength(PhoneModelMaxLength)]
        [Required]
        public string Model { get; set; } = string.Empty;
        [Comment("Phone price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Comment("Phone image URL")]
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Comment("Owner identifier")]
        [Required]
        public int OwnerId { get; set; }
        [Required]
        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; } = null!;
        [Comment("Phone category identifier")]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey(nameof(CategoryId))]
        public CategoryType CategoryType { get; set; } = null!;
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
