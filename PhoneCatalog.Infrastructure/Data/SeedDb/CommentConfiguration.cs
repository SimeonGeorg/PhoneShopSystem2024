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
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
               .HasOne(c => c.Phone)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PhoneId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Owner)
                .WithMany(o => o.Comments)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Comment[] { data.PositiveComment });
        }
    }
}
