using PhoneCatalog.Core.Models.Performance;

namespace PhoneCatalog.Core.Models.Phone
{
    public class PhoneDetailsServiceModel : PhoneServiceModel
    {
        public string Category { get; set; } = null!;
        public string OwnerPhoneNumber { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public PerformanceDetailsModel Performances { get; set; } = null!;

    }
}
