using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;

namespace PhoneCatalog.Infrastructure.Data.Models
{
    [Comment("Phone comment")]
        public class Comment
        {
            [Key]
            [Comment("Comment identifier")]
            public int Id { get; set; }
            [Required]
            [Comment("Coment text")]
            [StringLength(CommentMaxLength)]
            public string CommentText { get; set; } = string.Empty;
            [Required]
            [Comment("Phone identifier")]
            public int PhoneId { get; set; }
            [ForeignKey(nameof(PhoneId))]
            public Phone Phone { get; set; } = null!;
            [Required]
            [Comment("Owner identifier")]
            public int OwnerId { get; set; }
            [ForeignKey(nameof(OwnerId))]
            public Owner Owner { get; set; } = null!;

        }
    }
