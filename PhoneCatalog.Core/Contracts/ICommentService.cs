using PhoneCatalog.Core.Models.Comment;

namespace PhoneCatalog.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentServiceModel>> AllCommentByOwnerId(int ownerId);
        Task<IEnumerable<CommentServiceModel>> AllCommentByUserId(string userId);
        Task<int> CreateAsync(CommentAddModel commentModel);
        Task<IEnumerable<CommentServiceModel>> GetMineComents(int ownerId);
        Task <CommentPhoneDisplayModel> GetPhoneCommentsModels(int phoneId);
        Task<IEnumerable<CommentServiceModel>> AllCommentsByPhoneId(int phoneId);
        
    }
}
