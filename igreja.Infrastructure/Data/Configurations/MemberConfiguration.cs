using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Net.Mail;
using System.Reflection.Emit;

namespace igreja.Infrastructure.Data.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Email).HasMaxLength(100);
            builder.Property(m => m.Telefone).HasMaxLength(20);
            builder.Property(m => m.CPF).IsRequired().HasMaxLength(11);
            builder.Property(m => m.MemberFunction).HasMaxLength(100);

            // Configura o relacionamento um-para-um
            builder.HasOne(m => m.Address)
                   .WithOne(a => a.Member)
                   .HasForeignKey<Member>(m => m.AddressId)
                   .OnDelete(DeleteBehavior.NoAction);

            // Configuração do relacionamento entre Member e Attachments
            builder.HasOne(m => m.Attachment)
            .WithOne(a => a.Member)
                .HasForeignKey<Member>(a => a.AttachmentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
