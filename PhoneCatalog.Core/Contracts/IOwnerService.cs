using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface IOwnerService
    {
        Task<bool> IsExistByIdAsync(string userId);
        Task<int?> GetOwnerIdAsync(string userId);
    }
}
