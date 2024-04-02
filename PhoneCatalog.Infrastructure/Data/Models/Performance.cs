using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Infrastructure.Data.Models
{
    [Comment("Phone Performance")]
    public class Performance
    {
        [Key]
        [Comment("Phone identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("Phone RAM memory")]
        [StringLength(PhonePerformanceMaxLength)]
        public string Ram { get; set; } = string.Empty;
        [Required]
        [Comment("Phone processor")]
        [StringLength(PhonePerformanceMaxLength)]
        public string Processor { get; set; } = string.Empty;
        [Required]
        [Comment("Phone storage")]
        [StringLength(PhonePerformanceMaxLength)]
        public string Storage { get; set; } = string.Empty;
        [Required]
        [Comment("Phone camera pixels")]
        [StringLength(PhonePerformanceMaxLength)]
        public string CameraPxl { get; set; } = string.Empty;
        [Required]
        [Comment("Phone battery")]
        [StringLength(PhonePerformanceMaxLength)]
        public string Battery { get; set; } = string.Empty;
        [Required]
        [Comment("Phone identifier")]
        public int PhoneId { get; set; }
        [ForeignKey(nameof(PhoneId))]
        public Phone Phone { get; set; } = null!;
    }
}
