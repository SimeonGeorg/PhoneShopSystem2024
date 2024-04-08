using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneCatalog.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCatalog.Infrastructure.Data.SeedDb
{
    internal class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            var data = new SeedData();

           builder.HasData(new Performance[] { data.IphonePerformance , data.SamsungPerformance, data.NokiaPerformance });
        }
    }
}
