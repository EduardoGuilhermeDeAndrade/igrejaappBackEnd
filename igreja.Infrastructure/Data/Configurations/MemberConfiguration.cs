using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(m => m.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(m => m.MemberFunction)
                   .HasMaxLength(100);

            builder.HasOne(m => m.Church)
                   .WithMany(i => i.Members)
                   .HasForeignKey(m => m.ChurchId);

            builder.HasMany(m => m.FinancialMovements)
                   .WithOne(mv => mv.Member)
                   .HasForeignKey(mv => mv.MemberId);
        }
    }
}
