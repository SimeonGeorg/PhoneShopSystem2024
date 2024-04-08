using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneCatalog.Infrastructure.Data.Models;
using PhoneCatalog.Infrastructure.Data.SeedDb;

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
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new CategoryTypeConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new PerformanceConfiguration());
            builder.ApplyConfiguration(new PhoneConfiguration());

            base.OnModelCreating(builder);
        }
        
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<CategoryType> CategoryTypes { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Performance> Performances { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
    }
}