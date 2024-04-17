using System.ComponentModel.DataAnnotations;

namespace PhoneCatalog.Core.Models.Comment
{
    public class CommentPhoneDisplayModel
    {
        
        [Display(Name = "Phone Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        [Display(Name = "Phone Brand")]
        public string Brand { get; set; } = string.Empty;
        [Display(Name = "Phone Model")]
        public string Model { get; set; } = string.Empty;

        public IEnumerable<CommentServiceModel> Comments = new List<CommentServiceModel>();

    }
}
