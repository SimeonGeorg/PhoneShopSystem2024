using PhoneCatalog.Core.Contracts;

namespace PhoneCatalog.Core.Models.Phone
{
    public class AllPhoneServiceModel : IPhoneModel
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
