using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Models.Phone
{
    public class PhoneDetailsServiceModel : PhoneServiceModel
    {
        public string Category { get; set; } = null!;
        public string OwnerPhoneNumber { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public PerformanceDetailsModel Performances { get; set; } = null!;

    }
}
