using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class AttachentsConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            // Configura a chave primária
            builder.HasKey(j => j.Id);

            // Propriedades obrigatórias
            builder.Property(a => a.FileName)
                .IsRequired().HasMaxLength(255);

            builder.Property(a => a.ContentType)
                .IsRequired().HasMaxLength(100);

            builder.Property(a => a.Data)
                .IsRequired();

            builder.Property(a => a.UploadedAt)
                .IsRequired();
        }
    }

}
