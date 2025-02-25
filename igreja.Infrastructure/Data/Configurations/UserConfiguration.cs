using igreja.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace igreja.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Configuração da chave primária
            builder.HasKey(u => u.Id);

            // Configurações de propriedades
            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(100); // Define um limite de caracteres para Username

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(200); // Define um limite de caracteres para o hash da senha

            builder.Property(u => u.Role)
                   .IsRequired()
                   .HasMaxLength(50); // Limite para o papel do usuário (Admin, User, etc.)

            builder.Property(u => u.IsResponsableMyTask)
                   .IsRequired(); // Campo obrigatório

            builder.Property(u => u.IgrejaTenantId)
                .IsRequired(); // Chave estrangeira



            // Configuração de propriedades herdadas
            builder.Property(u => u.UserId)
                   .IsRequired();

            builder.Property(u => u.Created)
                   .IsRequired();

            builder.Property(u => u.Deleted)
                   .HasDefaultValue(false); // Define o valor padrão como falso

            // Relacionamento de navegação inverso (se necessário)
            // Relacionamentos podem ser configurados aqui caso o User tenha coleções relacionadas

            // Índices
            builder.HasIndex(u => u.UserName)
                   .IsUnique(); // Username deve ser único
        }
    }
}
