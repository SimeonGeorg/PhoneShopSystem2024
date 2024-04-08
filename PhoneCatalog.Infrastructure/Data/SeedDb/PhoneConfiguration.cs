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
    internal class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder
                 .HasOne(p => p.CategoryType)
                 .WithMany(ct => ct.Phones)
                 .HasForeignKey(p => p.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Owner)
                .WithMany(o => o.Phones)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

          builder.HasData(new Phone[] { data.Iphone, data.Samsung, data.Nokia });
        }
    }
}
