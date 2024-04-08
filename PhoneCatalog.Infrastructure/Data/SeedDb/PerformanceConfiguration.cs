using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneCatalog.Infrastructure.Data.Models;

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
