using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Core.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly IRepository repository;
        public PerformanceService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<int> CreateAsync(PhoneAddModel model, int phoneId)
        {
            Performance performance = new Performance()
            {

                Processor = model.Performances.Processor,
                Ram = model.Performances.Ram,
                Storage = model.Performances.Storage,
                CameraPxl = model.Performances.CameraPxl,
                Battery = model.Performances.Battery,
                PhoneId = phoneId
            };
            await repository.AddAsync(performance);
            await repository.SaveChangesAsync();
            return performance.Id;
        }
        public async Task<PerformanceEditFormModel> GetPerformancesByPhoneId(int phoneId)
        {
            var performances = await repository.AllNoTracking<Performance>()
              .Where(perf => perf.PhoneId == phoneId)
              .Select(perf => new PerformanceEditFormModel()
              {
                 Id = perf.Id,
                 Processor = perf.Processor,
                 Ram = perf.Ram,
                 Battery = perf.Battery,
                 PhoneId = phoneId,
                 CameraPxl = perf.CameraPxl,
                 Storage = perf.Storage,
                
              })
              .FirstOrDefaultAsync();

            return performances;
        }
        public async Task<PerformanceDetailsModel> GetPerformancesByPhoneIdForDelete(int phoneId)
        {
            var performances = await repository.AllNoTracking<Performance>()
              .Where(perf => perf.PhoneId == phoneId)
              .Select(perf => new PerformanceDetailsModel()
              {
                  Id = perf.Id,
                  Processor = perf.Processor,
                  Ram = perf.Ram,
                  Battery = perf.Battery,
                  PhoneId = phoneId,
                  CameraPxl = perf.CameraPxl,
                  Storage = perf.Storage,

              })
              .FirstOrDefaultAsync();

            return performances;
        }

    }
}
