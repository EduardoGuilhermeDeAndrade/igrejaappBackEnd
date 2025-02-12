using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class AccountApplicationConfiguration : IEntityTypeConfiguration<AccountApplication>
    {
        public void Configure(EntityTypeBuilder<AccountApplication> builder)
        {
            // Chave Primária
            builder.HasKey(aa => aa.Id);

            // Propriedades obrigatórias
            builder.Property(aa => aa.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(aa => aa.Descripton)
                   .HasMaxLength(500);

            builder.Property(aa => aa.Number)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(aa => aa.Status)
                   .IsRequired();

            // Relacionamento com FinancialMovement (um para muitos)
            builder.HasMany(aa => aa.FinancialMovements)
                   .WithOne(fm => fm.AccountApplications)
                   .HasForeignKey(fm => fm.AccountApplicationId)
                   .OnDelete(DeleteBehavior.Restrict); // Evita exclusão em cascata
        }
    }
}
