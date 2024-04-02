using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PhoneCatalog.Infrastructure.Data
{
    public class PhoneCatalogDbContext : IdentityDbContext
    {
        public PhoneCatalogDbContext(DbContextOptions<PhoneCatalogDbContext> options)
            : base(options)
        {
        }
    }
}