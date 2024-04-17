using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PhoneCatalog.Infrastructure.Constants.DataConstants;
using static PhoneCatalog.Core.Constants.MessageConstants;


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


