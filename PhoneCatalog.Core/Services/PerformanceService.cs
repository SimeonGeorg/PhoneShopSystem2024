using PhoneCatalog.Core.Contracts;
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
    }
}
