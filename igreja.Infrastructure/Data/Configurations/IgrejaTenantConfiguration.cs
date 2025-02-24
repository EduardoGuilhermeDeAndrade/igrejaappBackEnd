using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class IgrejaTenantConfiguration : IEntityTypeConfiguration<IgrejaTenant>
    {
        public void Configure(EntityTypeBuilder<IgrejaTenant> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired().HasMaxLength(100);

            // Relacionamentos
            builder.HasMany(i => i.Users)
                   .WithOne(u => u.IgrejaTenans)
                   .HasForeignKey(u => u.IgrejaTenantId);

            //builder.HasMany(i => i.Members)
            //       .WithOne(m => m.IgrejaTenant)
            //       .HasForeignKey(m => m.IgrejaTenantId);

            //builder.HasMany(i => i.Temples)
            //       .WithOne(t => t.Igreja)
            //       .HasForeignKey(t => t.IgrejaId);
        }
    }
}
