using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Infrastructure.Data.Models
{
    [Comment("Phone Owner")]
    public class Owner
    {
        [Comment("Owner identifier")]
        [Key]
        public int Id { get; set; }
        [Comment("Owner  name")]
        [Required]
        [StringLength(OwnerNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Comment("Owner Phone number")]
        [StringLength(OwnerPhoneNumberMaxLength)]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Comment("Owner email address")]
        [Required]
        [StringLength(OwnerEmailMaxLength)]
        public string Email { get; set; } = string.Empty;
        [Comment("User identifier")]
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        public IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
