using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Owner;

namespace PhoneCatalog.Core.Contracts
{
    public interface IOwnerService
    {
        Task<bool> IsExistByIdAsync(string userId);
        Task<int?> GetOwnerIdAsync(string userId);
        Task CreateAsync(string userId, string phoneNumber);
        Task<bool> OwnerWithPhoneNumberExistsAsync(string phoneNumber);
        Task<OwnerPersonalModel> GetOwnerPersonalInfo(int ownerId);
        Task AddCommentToOwner(int? ownerId, CommentAddModel commentModel);

    }
}
