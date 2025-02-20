using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using igreja.Domain.Models.General;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace igreja.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IUserContextProvider _userContextProvider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserContextProvider userContextProvider)
            : base(options)
        {
            _userContextProvider = userContextProvider;
            Console.WriteLine("🔄 Novo ApplicationDbContext criado!");
        }
        
        public DbSet<User> Users { get; set; }
        //public DbSet<MyTask> MyTasks { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<IgrejaTenant> Tenants { get; set; }


        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyGlobalFilters(modelBuilder);
        }

        private void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(EntityTenantUser).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    // Propriedades da entidade
                    var isDeletedProperty = Expression.Property(parameter, nameof(EntityTenantUser.Deleted));
                    var tenantIdProperty = Expression.Property(parameter, nameof(EntityTenantUser.TenantId));
                    var userIdProperty = Expression.Property(parameter, nameof(EntityTenantUser.UserId));

                    // Métodos auxiliares para obter os valores dinamicamente
                    var tenantIdMethod = typeof(ApplicationDbContext).GetMethod(nameof(GetTenantId), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    var userIdMethod = typeof(ApplicationDbContext).GetMethod(nameof(GetUserId), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

                    var tenantIdValue = Expression.Call(Expression.Constant(this), tenantIdMethod);
                    var userIdValue = Expression.Call(Expression.Constant(this), userIdMethod);

                    // Conversão para Guid (necessária para evitar erros de tipo)
                    var tenantIdCondition = Expression.Equal(tenantIdProperty, Expression.Convert(tenantIdValue, typeof(Guid)));
                    var userIdCondition = Expression.Equal(userIdProperty, Expression.Convert(userIdValue, typeof(Guid)));
                    var isDeletedCondition = Expression.Equal(isDeletedProperty, Expression.Constant(false));

                    // Combina as condições
                    var combinedCondition = Expression.AndAlso(userIdCondition, Expression.AndAlso(tenantIdCondition, isDeletedCondition));

                    // Cria a expressão lambda e adiciona como filtro global
                    var lambda = Expression.Lambda(combinedCondition, parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter((dynamic)lambda);
                }
            }
        }

        // Métodos auxiliares para obter os valores dinamicamente
        private Guid GetTenantId() => _userContextProvider.GetCurrentTenantId();
        private Guid GetUserId() => _userContextProvider.GetCurrentUserId();

        private Expression GetDynamicTenantIdCondition(ParameterExpression parameter)
        {
            var tenantIdProperty = Expression.Property(parameter, nameof(EntityTenantUser.TenantId));
            var tenantIdMethod = typeof(IUserContextProvider).GetMethod(nameof(IUserContextProvider.GetCurrentTenantId));

            // Chama _userContextProvider.GetCurrentTenantId() dinamicamente
            var tenantIdValue = Expression.Call(Expression.Constant(_userContextProvider), tenantIdMethod);

            return Expression.Equal(tenantIdProperty, tenantIdValue);
        }

        //Como Funciona
        //O método GetDynamicUserIdCondition usa reflexão para chamar _userContextProvider.GetCurrentUserId() sempre que a consulta é executada.
        //Isso evita que o valor de UserId seja fixado no momento da configuração do filtro.
        private Expression GetDynamicUserIdCondition(ParameterExpression parameter)
        {
            var userIdProperty = Expression.Property(parameter, nameof(EntityTenantUser.UserId));
            var userIdMethod = typeof(IUserContextProvider).GetMethod(nameof(IUserContextProvider.GetCurrentUserId));

            // Cria uma chamada para _userContextProvider.GetCurrentUserId()
            var userIdValue = Expression.Call(Expression.Constant(_userContextProvider), userIdMethod);

            // Condição UserId
            return Expression.Equal(userIdProperty, userIdValue);
        }

        public override int SaveChanges()
        {
            SetUserIdForEntities();
            SetTenantIdForEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetUserIdForEntities();
            SetTenantIdForEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetUserIdForEntities()
        {
            var userId = _userContextProvider.GetCurrentUserId();

            if (userId == Guid.Empty)
                return;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EntityTenantUser entityUser && entry.State == EntityState.Added)
                {
                    if (entityUser.UserId == Guid.Empty) // Só define se estiver vazio
                    {
                        entityUser.UserId = userId;
                    }
                }
            }
        }

        private void SetTenantIdForEntities()
        {
            var tenantId = _userContextProvider.GetCurrentTenantId();

            if (tenantId == Guid.Empty)
                return;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EntityTenantUser entityTenant && entry.State == EntityState.Added)
                {
                    if (entityTenant.TenantId == Guid.Empty) // Define apenas se estiver vazio
                    {
                        entityTenant.TenantId = tenantId;
                    }
                }
            }
        }
    }
}
