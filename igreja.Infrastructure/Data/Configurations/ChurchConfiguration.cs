
using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class ChurchConfiguration : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(i => i.Address)
                   .HasMaxLength(500);

            builder.HasMany(i => i.Temples)
                   .WithOne(t => t.Church)
                   .HasForeignKey(t => t.ChurchId);

            builder.HasMany(i => i.Members)
                   .WithOne(m => m.Church)
                   .HasForeignKey(m => m.ChurchId);
        }
    }
}
