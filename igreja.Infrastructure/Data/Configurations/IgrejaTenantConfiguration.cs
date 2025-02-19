using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class IgrejaTenantConfiguration : IEntityTypeConfiguration<IgrejaTenant>
    {
        public void Configure(EntityTypeBuilder<IgrejaTenant> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(200);

        }
    }
}
