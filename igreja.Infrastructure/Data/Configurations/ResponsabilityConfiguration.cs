using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class ResponsabilityConfiguration : IEntityTypeConfiguration<Responsibility>
    {
        public void Configure(EntityTypeBuilder<Responsibility> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);

            // Relacionamentos
            builder.HasMany(c => c.Assignments)
                   .WithOne(a => a.Responsibility)
                   .HasForeignKey(a => a.ResponsibilityId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
