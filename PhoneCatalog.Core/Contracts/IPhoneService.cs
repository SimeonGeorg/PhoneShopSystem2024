using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Models.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface IPhoneService
    {
        Task<IEnumerable<AllPhoneServiceModel>> AllPhonesAsync();
        Task<IEnumerable<PhoneServiceModel>> AllPhonesByOwnerIdAsync(int ownerId);
        Task<IEnumerable<PhoneServiceModel>> AllPhonesByUserIdAsync(string userId);
        Task<bool> ExistsAsync(int id);
        Task<PhoneDetailsServiceModel> PhoneDetailsByIdAsync(int id);
        Task<PerformanceDetailsModel> PerformanceDetailsByPhoneIdAsync(int id);
        Task<PerformanceDetailsModel> AllPerformanceAsync();
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<IEnumerable<PhoneCategoriesServiceModel>> AllCategoriesAsync();
        Task<CommentServiceModel> AllCommentsAsync();
        Task<int> CreateAsync(PhoneAddModel model,int ownerId);
        Task<bool> HasOwnerWithId(int phoneid, string id);
        Task<PhoneEditFormModel> GetPhoneEditFormByIdAsync(int phoneId);
        Task EditAsync(int phoneId, PhoneEditFormModel model);



    }
}
