using PhoneCatalog.Core.Models.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface IPerformanceService
    {
        Task<int> CreateAsync(PhoneAddModel model, int phoneId);
    }
}
