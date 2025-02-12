using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class TemplesConfiguration : IEntityTypeConfiguration<Temple>
    {
        public void Configure(EntityTypeBuilder<Temple> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Adress)
                   .HasMaxLength(500);

            builder.HasOne(t => t.Church)
                   .WithMany(i => i.Temples)
                   .HasForeignKey(t => t.ChurchId);

            builder.HasMany(t => t.FinancialMovements)
                   .WithOne(m => m.Temple)
                   .HasForeignKey(m => m.TempleId);
        }
    }
}
