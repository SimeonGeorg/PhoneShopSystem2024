using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using PhoneCatalog.Core.Contracts;
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
    }
}

