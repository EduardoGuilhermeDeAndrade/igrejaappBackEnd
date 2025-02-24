using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net.Mail;
using System.Reflection.Emit;

namespace igreja.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(100);
            builder.Property(u => u.NivelAcesso)
                   .IsRequired();
            builder.Property(u => u.Role)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.Property(u => u.IgrejaTenantId)
                   .IsRequired();

            // Propriedades herdadas
            builder.Property(u => u.UserId)
                   .IsRequired();
            builder.Property(u => u.Created)
                   .IsRequired();
            builder.Property(u => u.Deleted)
                   .HasDefaultValue(false);

            // Índices
            builder.HasIndex(u => u.UserName)
                   .IsUnique();
            builder.HasIndex(u => u.Email)
                   .IsUnique();

            // Relacionamento com Attachment
            builder.HasOne(u => u.Attachment)
                   .WithOne(a => a.User)
                   .HasForeignKey<User>(u => u.AttachmentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
