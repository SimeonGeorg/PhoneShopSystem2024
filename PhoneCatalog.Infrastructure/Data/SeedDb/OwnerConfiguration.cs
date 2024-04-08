using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Infrastructure.Data.SeedDb
{
    internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            var data = new SeedData();
            builder.HasData(new Owner[] { data.IphoneOwner, data.SamsungOwner , data.NokiaOwner });
        }
    }
}
