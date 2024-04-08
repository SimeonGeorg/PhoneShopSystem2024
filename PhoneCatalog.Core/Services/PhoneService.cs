using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models;
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
    }
}
