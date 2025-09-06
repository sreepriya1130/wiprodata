using System.Globalization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoleBasedProductMgmt.Models;

namespace RoleBasedProductMgmt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IDataProtector _protector;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IDataProtectionProvider dataProtectionProvider) : base(options)
        {
            _protector = dataProtectionProvider.CreateProtector("ProductPriceProtector");
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var priceConverter = new ValueConverter<decimal, string>(
                v => _protector.Protect(v.ToString(CultureInfo.InvariantCulture)),
                v => decimal.Parse(_protector.Unprotect(v), CultureInfo.InvariantCulture));

            builder.Entity<Product>(e =>
            {
                e.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                // store encrypted as nvarchar(max) column named EncryptedPrice
                e.Property(p => p.Price)
                    .HasConversion(priceConverter)
                    .HasColumnName("EncryptedPrice");

                e.Property(p => p.CreatedAtUtc)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
