using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Infrastructure.Data.Models;

namespace PhoneCatalog.Infrastructure.Data
{
    public class PhoneCatalogDbContext : IdentityDbContext
    {
        public PhoneCatalogDbContext(DbContextOptions<PhoneCatalogDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Phone>()
                  .HasOne(p => p.CategoryType)
                  .WithMany(ct => ct.Phones)
                  .HasForeignKey(p => p.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Phone>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Phones)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c => c.Phone)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PhoneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Comment>()
                .HasOne(c=>c.Owner)
                .WithMany(o=>o.Comments)
                .HasForeignKey(c=>c.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            


            //builder.ApplyConfiguration(new CategoryTypeConfiguration());
            //builder.ApplyConfiguration(new CommentConfiguration());
            //builder.ApplyConfiguration(new OwnerConfiguration());
            //builder.ApplyConfiguration(new PerformanceConfiguration());
            //builder.ApplyConfiguration(new PhoneConfiguration());

            base.OnModelCreating(builder);
        }
        public DbSet<CategoryType> CategoryTypes { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<Performance> Performances { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
    }
}