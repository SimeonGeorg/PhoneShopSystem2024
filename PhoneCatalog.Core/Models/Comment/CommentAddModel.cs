using System.ComponentModel.DataAnnotations;
using static PhoneCatalog.Core.Constants.MessageConstants;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;


namespace PhoneCatalog.Core.Models.Comment
{
    public class CommentAddModel
    {

        [Display(Name = "Comment identifier")]
        public int Id { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Coment text")]
        [StringLength(CommentMaxLength,
            MinimumLength = CommentMinLength,
            ErrorMessage = LengthMessage)]
        public string CommentText { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Phone identifier")]
        public int PhoneId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Owner identifier")]
        public int OwnerId { get; set; }
    }
}


