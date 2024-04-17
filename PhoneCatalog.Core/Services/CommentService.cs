using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
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

        public async Task <CommentPhoneDisplayModel> GetPhoneCommentsModels(int phoneId)
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

        public async Task <IEnumerable<CommentServiceModel>> AllCommentsByPhoneId (int phoneId)
        {
            return await repository.AllNoTracking<Comment>()
                .Where(c => c.PhoneId == phoneId)
                .Select(c => new CommentServiceModel()
                {
                    Id = c.Id,
                    CommentText = c.CommentText,
                    PhoneId = c.PhoneId,
                    OwnerId= c.OwnerId
                }).ToListAsync();
        }
    }
}

