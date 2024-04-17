using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;

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
                   Id = c.Id,
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

        public async Task<int> CreateAsync(CommentAddModel model)
        {
            Comment comment = new Comment()
            {
                Id = model.Id,
                CommentText = model.CommentText,
                OwnerId = model.OwnerId,
                PhoneId = model.PhoneId
            };

            await repository.AddAsync(comment);
            await repository.SaveChangesAsync();

            return comment.Id;
        }
        public async Task<IEnumerable<CommentServiceModel>> GetMineComents(int ownerId)
        {
            return await repository.AllNoTracking<Comment>()
               .Where(c => c.OwnerId == ownerId)
               .Select(c => new CommentServiceModel()
               {
                   Id = c.Id,
                   CommentText = c.CommentText,
                   OwnerId = c.OwnerId,
                   PhoneId = c.PhoneId
               })
               .ToListAsync();
        }

        public async Task<CommentPhoneDisplayModel> GetPhoneCommentsModels(int phoneId)
        {
            return await repository.AllNoTracking<Phone>()
                .Where(p => p.Id == phoneId)
                .Select(p => new CommentPhoneDisplayModel()
                {
                    ImageUrl = p.ImageUrl,
                    Brand = p.Brand,
                    Model = p.Model,
                }).FirstAsync();

        }

        public async Task<IEnumerable<CommentServiceModel>> AllCommentsByPhoneId(int phoneId)
        {
            return await repository.AllNoTracking<Comment>()
                .Where(c => c.PhoneId == phoneId)
                .Select(c => new CommentServiceModel()
                {
                    Id = c.Id,
                    CommentText = c.CommentText,
                    PhoneId = c.PhoneId,
                    OwnerId = c.OwnerId
                }).ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllNoTracking<Comment>()
               .AnyAsync(c => c.Id == id);
        }
        public async Task<bool> HasOwnerWithId(int commentId, string userId)
        {
            return await repository.AllNoTracking<Comment>()
                .AnyAsync(c => c.Id == commentId && c.Owner.UserId == userId);
        }

        public async Task<CommentAddModel> GetCommentEditFormByIdAsync(int commentId)
        {
            var comment = await repository.AllNoTracking<Comment>()
              .Where(c => c.Id == commentId)
              .Select(c => new CommentAddModel()
              {
                  Id = c.Id,
                  CommentText = c.CommentText,
                  PhoneId = c.PhoneId,
                  OwnerId = c.OwnerId
              })
              .FirstOrDefaultAsync();

            if (comment != null)
            {
                comment.Id = commentId;
            }

            return comment;

        }

        public async Task EditAsync(int commentId, CommentAddModel model)
        {
            var comment = await repository.GetByIdAsync<Comment>(commentId);


            if (comment != null)
            {
                comment.OwnerId = model.OwnerId;
                comment.CommentText = model.CommentText;
                comment.PhoneId = model.PhoneId;

                await repository.SaveChangesAsync();
            }
        }
    }
}

