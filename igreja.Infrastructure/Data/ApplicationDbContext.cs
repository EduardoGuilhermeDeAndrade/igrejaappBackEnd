using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using igreja.Domain.Models.General;
using igreja.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using System;
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
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<Temple> Temples { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Church> Churchs { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<FinancialMovement> FinancialMovements { get; set; }
        public DbSet<AccountApplication> AccountApplications { get; set; }

        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplyGlobalFilters(modelBuilder);
        }

        //private void ApplyGlobalFilters(ModelBuilder modelBuilder)
        //{
        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        if (typeof(EntityUser).IsAssignableFrom(entityType.ClrType))
        //        {
        //            var parameter = Expression.Parameter(entityType.ClrType, "e");

        //            // Propriedade Deleted
        //            var isDeletedProperty = Expression.Property(parameter, nameof(EntityUser.Deleted));
        //            var isDeletedCondition = Expression.Equal(isDeletedProperty, Expression.Constant(false));

        //            // Condição UserId dinâmica
        //            var userIdCondition = GetDynamicUserIdCondition(parameter);

        //            // Combina as condições (UserId e Deleted)
        //            var combinedCondition = Expression.AndAlso(userIdCondition, isDeletedCondition);

        //            // Cria a expressão lambda
        //            var lambda = Expression.Lambda(combinedCondition, parameter);

        //            modelBuilder.Entity(entityType.ClrType).HasQueryFilter((dynamic)lambda);
        //        }
        //    }
        //}

        private void ApplyGlobalFilters(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                // Obtém a propriedade "Deleted" dinamicamente
                var deletedProperty = clrType.GetProperty("Deleted");
                // Obtém a propriedade "UserId" dinamicamente
                var userIdProperty = clrType.GetProperty("UserId");

                if (deletedProperty != null || userIdProperty != null)
                {
                    // Parâmetro da expressão (representa a entidade "e")
                    var parameter = Expression.Parameter(clrType, "e");

                    Expression combinedCondition = null;

                    // Condição para Deleted == false
                    if (deletedProperty != null)
                    {
                        var isDeletedProperty = Expression.Property(parameter, deletedProperty);
                        var isDeletedCondition = Expression.Equal(isDeletedProperty, Expression.Constant(false));
                        combinedCondition = isDeletedCondition;
                    }

                    // Condição dinâmica para UserId == CurrentUserId
                    if (userIdProperty != null)
                    {
                        var userIdPropertyAccess = Expression.Property(parameter, userIdProperty);
                        var userIdCondition = Expression.Equal(userIdPropertyAccess, Expression.Constant(_userContextProvider.GetCurrentUserId()));

                        combinedCondition = combinedCondition != null
                            ? Expression.AndAlso(combinedCondition, userIdCondition)
                            : userIdCondition;
                    }

                    if (combinedCondition != null)
                    {
                        // Cria a expressão lambda
                        var lambda = Expression.Lambda(combinedCondition, parameter);

                        // Aplica o filtro global
                        modelBuilder.Entity(clrType).HasQueryFilter((dynamic)lambda);
                    }
                }
            }
        }


        //Como Funciona
        //O método GetDynamicUserIdCondition usa reflexão para chamar _userContextProvider.GetCurrentUserId() sempre que a consulta é executada.
        //Isso evita que o valor de UserId seja fixado no momento da configuração do filtro.
        private Expression GetDynamicUserIdCondition(ParameterExpression parameter)
        {
            var userIdProperty = Expression.Property(parameter, nameof(EntityUser.UserId));
            var userIdMethod = typeof(IUserContextProvider).GetMethod(nameof(IUserContextProvider.GetCurrentUserId));

            // Cria uma chamada para _userContextProvider.GetCurrentUserId()
            var userIdValue = Expression.Call(Expression.Constant(_userContextProvider), userIdMethod);

            // Condição UserId
            return Expression.Equal(userIdProperty, userIdValue);
        }

        public override int SaveChanges()
        {
            SetUserIdForEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetUserIdForEntities();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetUserIdForEntities()
        {
            var userId = _userContextProvider.GetCurrentUserId();

            if (userId == Guid.Empty)
                return;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is EntityUser entityUser && entry.State == EntityState.Added)
                {
                    if (entityUser.UserId == Guid.Empty) // Só define se estiver vazio
                    {
                        entityUser.UserId = userId;
                    }
                }
            }
        }

    }
}
