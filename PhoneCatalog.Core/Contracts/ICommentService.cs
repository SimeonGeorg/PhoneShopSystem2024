using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentServiceModel>> AllCommentByOwnerId(int ownerId);
        Task<IEnumerable<CommentServiceModel>> AllCommentByUserId(string userId);
        Task<int> CreateAsync(CommentAddModel commentModel);
        Task<IEnumerable<CommentServiceModel>> GetMineComents(int ownerId);
        
    }
}
