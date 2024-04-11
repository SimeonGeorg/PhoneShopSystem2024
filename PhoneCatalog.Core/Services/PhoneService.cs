using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneCatalog.Core.Contracts;
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
                .Where(p=>p.Owner.UserId == userId)
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
    }
}
