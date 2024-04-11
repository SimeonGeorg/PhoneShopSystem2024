using PhoneCatalog.Core.Models.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Contracts
{
    public interface IPhoneService
    {
        Task<IEnumerable<AllPhoneServiceModel>> AllPhonesAsync();
        Task<IEnumerable<PhoneServiceModel>> AllPhonesByOwnerIdAsync(int ownerId);
        Task<IEnumerable<PhoneServiceModel>> AllPhonesByUserIdAsync(string userId);

    }
}
