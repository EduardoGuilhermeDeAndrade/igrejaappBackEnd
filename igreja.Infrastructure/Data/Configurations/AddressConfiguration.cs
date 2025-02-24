using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.City).IsRequired().HasMaxLength(100);
            builder.Property(e => e.District).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Number).IsRequired().HasMaxLength(10);
            builder.Property(e => e.Complement).HasMaxLength(100);

        }
    }
}

