using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class MyTaskConfiguration : IEntityTypeConfiguration<MyTask>
    {
        public void Configure(EntityTypeBuilder<MyTask> builder)
        {
            // Configura a chave primária
            builder.HasKey(j => j.Id);

            // Relacionamento com o usuário responsável (UserResponsable)
            builder.HasOne(j => j.UserResponsable)
                   .WithMany() // Caso o User não tenha uma coleção de Jobs
                   .HasForeignKey(j => j.UserResponsableId)
                   .OnDelete(DeleteBehavior.Restrict); // Evita exclusões em cascata

            // Propriedades obrigatórias
            builder.Property(j => j.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(j => j.Description)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(j => j.CompletionDate)
                   .IsRequired();
        }
    }

}
