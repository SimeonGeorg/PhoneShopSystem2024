using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Phone;
using System.ComponentModel.DataAnnotations;

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
