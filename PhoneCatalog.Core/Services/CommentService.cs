using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;
        public CommentService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<CommentServiceModel>> AllCommentByOwnerId(int ownerId)
        {
            return await repository.AllNoTracking<Comment>()
               .Where(c => c.OwnerId == ownerId)
               .Select(c => new CommentServiceModel()
               {
                   CommentText = c.CommentText,
                   OwnerId = ownerId,
                   PhoneId = c.PhoneId
               })
               .ToListAsync();
        }
        public async Task<IEnumerable<CommentServiceModel>> AllCommentByUserId(string userId)
        {
            return await repository.AllNoTracking<Comment>()
                .Where(c => c.Owner.UserId == userId)
                .Select(c => new CommentServiceModel()
                {
                    CommentText = c.CommentText,
                    OwnerId = c.OwnerId,
                    PhoneId = c.PhoneId
                })
                .ToListAsync();
        }

    }
}
