using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Models.Comment
{
    public class CommentPhoneDisplayModel
    {
        public int Id { get; set; }
        [Display(Name = "Phone Brand")]
        public string Brand { get; set; } = string.Empty;
        [Display(Name = "Phone Model")]
        public string Model { get; set; } = string.Empty;
        [Display(Name = "Phone price")]
        public decimal Price { get; set; }
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        public IEnumerable<CommentServiceModel> Comments = new List<CommentServiceModel>();

    }
}
