using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Owner;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repository;

        public OwnerService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<bool> IsExistByIdAsync(string userId)
        {
            return await repository.All<Owner>()
                .AnyAsync(a => a.UserId == userId);
        }
        public async Task<int?> GetOwnerIdAsync(string userId)
        {
            return (await repository.AllNoTracking<Owner>()
                .FirstOrDefaultAsync(o => o.UserId == userId))?.Id;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new Owner()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> OwnerWithPhoneNumberExistsAsync(string phoneNumber)
        {
            return await repository.AllNoTracking<Owner>()
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<OwnerPersonalModel> GetOwnerPersonalInfo(int ownerId)
        {
            return await repository.AllNoTracking<Owner>()
                .Where(o => o.Id == ownerId)
                .Select(o => new OwnerPersonalModel()
                {
                    Id = o.Id,
                    PhoneNumber = o.PhoneNumber,
                    UserId = o.UserId
                }).FirstAsync();
        }

        public async Task AddCommentToOwner(int? ownerId, CommentAddModel commentModel)
        {
            if (ownerId != null)
            {
                var owner = await repository.GetByIdAsync<Owner>(ownerId);
                var coment = new Comment()
                {
                    Id = commentModel.Id,
                    CommentText = commentModel.CommentText,
                    PhoneId = commentModel.PhoneId,
                    OwnerId = commentModel.OwnerId
                };

                if(owner != null)
                {
                    owner.Comments.ToList().Add(coment);
                    await repository.SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException("Owner not found");
            }
        }
    }
}


