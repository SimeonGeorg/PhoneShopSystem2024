using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Infrastructure.Data.SeedDb
{
    internal class CategoryTypeConfiguration : IEntityTypeConfiguration<CategoryType>
    {
        public void Configure(EntityTypeBuilder<CategoryType> builder)
        {
            var data = new SeedData();

            builder.HasData(new CategoryType[] {data.SmartPhoneCategory , data.MobilePhoneCategory });
        }
    }
}
