using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.Mail;
using System.Reflection.Emit;

namespace igreja.Infrastructure.Data.Configurations
{
    public class TempleConfiguration : IEntityTypeConfiguration<Temple>
    {
        public void Configure(EntityTypeBuilder<Temple> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

            // Configura o relacionamento um-para-um
            builder.HasOne(m => m.Address)
                   .WithOne(a => a.Temple)
                   .HasForeignKey<Temple>(m => m.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.Attachment)
                    .WithOne(a => a.Temple)
                    .HasForeignKey<Temple>(a => a.AttachmentId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
