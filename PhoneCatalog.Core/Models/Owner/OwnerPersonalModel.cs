using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Models.Comment;

namespace PhoneCatalog.Core.Models.Owner
{
    public class OwnerPersonalModel
    {
        public int Id { get; set; }

        [Display(Name ="Owner Phone number")]      
        public string PhoneNumber { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        
        public IEnumerable<PhoneServiceModel> Phones { get; set; } = new List<PhoneServiceModel>();
        public IEnumerable<CommentServiceModel> Comments { get; set; } = new List<CommentServiceModel>();
    }
}
