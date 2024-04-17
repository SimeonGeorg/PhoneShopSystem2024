using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Models.Phone;

namespace PhoneCatalog.Core.Contracts
{
    public interface IPerformanceService
    {
        Task<int> CreateAsync(PhoneAddModel model, int phoneId);
        Task<PerformanceEditFormModel>GetPerformancesByPhoneId(int phoneId);
        Task<PerformanceDetailsModel> GetPerformancesByPhoneIdForDelete(int phoneId);
    }
}
