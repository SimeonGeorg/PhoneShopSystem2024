using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Core.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IRepository repository;
        public PhoneService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<AllPhoneServiceModel>> AllPhonesAsync()
        {

            return await repository
                .AllNoTracking<Phone>()
                .Select(p => new AllPhoneServiceModel()
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                })
                .ToListAsync();

        }

        public async Task<IEnumerable<PhoneServiceModel>> AllPhonesByOwnerIdAsync(int ownerId)
        {
            return await repository.AllNoTracking<Phone>()

               .Where(p => p.OwnerId == ownerId)
               .Select(p => new PhoneServiceModel()
               {
                   Id = p.Id,
                   Brand = p.Brand,
                   Model = p.Model,
                   ImageUrl = p.ImageUrl,
                   Price = p.Price,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<PhoneServiceModel>> AllPhonesByUserIdAsync(string userId)
        {
            return await repository.AllNoTracking<Phone>()
                .Where(p => p.Owner.UserId == userId)
                .Select(p => new PhoneServiceModel()
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                })
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllNoTracking<Phone>()
               .AnyAsync(h => h.Id == id);
        }

        public async Task<PhoneDetailsServiceModel> PhoneDetailsByIdAsync(int id)
        {
            return await repository.AllNoTracking<Phone>()
                .Where(p => p.Id == id)
                .Select( p => new PhoneDetailsServiceModel()
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Category = p.CategoryType.Name,
                    OwnerPhoneNumber = p.Owner.PhoneNumber,
                    OwnerId = p.Owner.Id.ToString()
                })
                .FirstAsync();
        }
        public async Task<PerformanceDetailsModel> PerformanceDetailsByPhoneIdAsync(int id)
        {
            return await repository.AllNoTracking<Performance>()
                .Where (p => p.PhoneId == id)
                .Select (p => new PerformanceDetailsModel()
                {
                    Id = p.Id,
                    Ram = p.Ram,
                    Processor = p.Processor,
                    Battery = p.Battery,
                    CameraPxl = p.CameraPxl,
                    Storage = p.Storage,
                })
                .FirstAsync();
        }

        public async Task<PerformanceDetailsModel> AllPerformanceAsync()
        {
            return await repository.AllNoTracking<Performance>()
            .Select(perf => new PerformanceDetailsModel()
            {
                Id = perf.Id,
                Processor = perf.Processor,
                Battery = perf.Battery,
                CameraPxl = perf.CameraPxl,
                Storage = perf.Storage,
                Ram = perf.Ram
            })
            .FirstAsync();
        }

        public async Task<CommentServiceModel> AllCommentsAsync()
        {
            return await repository.AllNoTracking<Comment>()
            .Select(c => new CommentServiceModel()
            {
                Id = c.Id,
                CommentText = c.CommentText,
                PhoneId = c.PhoneId,
            }).FirstAsync();
            
        }

        public async Task<int> CreateAsync(PhoneAddModel model,int ownerId)
        {
                Phone phone = new Phone()
                {
                    Brand = model.Brand,
                    Model = model.Model,
                    Price = model.CategoryId,
                    ImageUrl = model.ImageUrl,
                    CategoryId = model.CategoryId,
                    OwnerId = ownerId,
                };
                
       

                await repository.AddAsync(phone);
                await repository.SaveChangesAsync();

                return phone.Id;
            
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllNoTracking<CategoryType>()
               .AnyAsync(c => c.Id == categoryId);
        }
        

        public async Task<IEnumerable<PhoneCategoriesServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllNoTracking<CategoryType>()
               .Select(c => new PhoneCategoriesServiceModel()
               {
                   Id = c.Id,
                   Name = c.Name,
               }).ToListAsync();
        }

        public async Task<bool> HasOwnerWithId(int phoneId, string userId)
        {
            return await repository.AllNoTracking<Phone>()
                .AnyAsync(p => p.Id == phoneId && p.Owner.UserId == userId);
        }

        public async Task<PhoneEditFormModel> GetPhoneEditFormByIdAsync(int phoneId)
        {
            var phone = await repository.AllNoTracking<Phone>()
                .Where(p => p.Id == phoneId)
                .Select(p => new PhoneEditFormModel()
                {
                    Brand = p.Brand,
                    Model = p.Model,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    CategoryId = p.CategoryId
                    
                })
                .FirstOrDefaultAsync();    

            if (phone != null)
            {
                phone.Categories = await AllCategoriesAsync();
            }

            return phone;
        }

        public async Task EditAsync(int phoneId, PhoneEditFormModel model)
        {
            var phone = await repository.GetByIdAsync<Phone>(phoneId);
            var performance = await repository.GetByIdAsync<Performance>(model.Performances.Id);

            if (phone != null)
            {
                phone.Brand = model.Brand;
                phone.Model = model.Model;
                phone.Price = model.Price;
                phone.ImageUrl = model.ImageUrl;
                phone.CategoryId = model.CategoryId;
                
                await repository.SaveChangesAsync();
            }
            if (performance != null)
            {
                performance.Storage = model.Performances.Storage;
                performance.Processor = model.Performances.Processor;
                performance.Battery = model.Performances.Battery;
                performance.CameraPxl = model.Performances.CameraPxl;
                performance.Ram = model.Performances.Ram;
                performance.Id = model.Performances.Id;
                performance.PhoneId = phoneId;
                await repository.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int phoneId)
        {
            await repository.DeleteAsync<Phone>(phoneId);
            await repository.SaveChangesAsync();
        }
    }
}

