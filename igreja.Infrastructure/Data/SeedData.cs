using igreja.Domain.Models;

namespace igreja.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
        //    if (!context.Tenants.Any())
        //    {
        //        context.Tenants.AddRange(
        //            new IgrejaTenant
        //            {
        //                Id = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDE01"),
        //                Name = "Tenant 1",
        //                Description = "Primeiro tenant"
        //            },
        //            new IgrejaTenant
        //            {
        //                Id = Guid.Parse("B2C3D4E5-F678-9012-3456-789ABCDE0123"),
        //                Name = "Tenant 2",
        //                Description = "Segundo tenant"
        //            }
        //            );

        //        if (!context.Users.Any())
        //        {
        //            context.Users.AddRange(
        //            new User
        //            {
        //                Id = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
        //                UserName = "admin",
        //                Email = "admin@gmail.com",
        //                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), // Criptografa a senha
        //                Role = "Admin",
        //                Created = DateTime.UtcNow,
        //                IsResponsableMyTask = true,
        //                TenantId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDE01"),
        //                UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")
        //            },
        //            new User
        //            {
        //                Id = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
        //                UserName = "user",
        //                Email = "user@gmail.com",
        //                PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
        //                Role = "User",
        //                Created = DateTime.UtcNow,
        //                IsResponsableMyTask = false,
        //                TenantId = Guid.Parse("A1B2C3D4-E5F6-7890-1234-56789ABCDE01"),
        //                UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")
        //            },
        //            new User
        //            {
        //                Id = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492"),
        //                UserName = "userA",
        //                Email = "userA@gmail.com",
        //                PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
        //                Role = "User",
        //                Created = DateTime.UtcNow,
        //                IsResponsableMyTask = false,
        //                TenantId = Guid.Parse("B2C3D4E5-F678-9012-3456-789ABCDE0123"),
        //                UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")
        //            },
        //            new User
        //            {
        //                Id = Guid.Parse("30C87EFC-39B6-4A4E-8BF8-2B14FC665384"),
        //                UserName = "userB",
        //                Email = "userB@gmail.com",
        //                PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
        //                Role = "User",
        //                Created = DateTime.UtcNow,
        //                IsResponsableMyTask = false,
        //                TenantId = Guid.Parse("B2C3D4E5-F678-9012-3456-789ABCDE0123"),
        //                UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")
        //            }
        //        );
        //        }

        //        //if (!context.MyTasks.Any())
        //        //{
        //        //    context.MyTasks.AddRange(
        //        //    new MyTask
        //        //    {
        //        //        Id = Guid.NewGuid(),
        //        //        Title = "Tarefa 01",
        //        //        Description = "Descrição da tarefa 01",
        //        //        Created = DateTime.UtcNow,
        //        //        CompletionDate = DateTime.UtcNow.AddDays(3),
        //        //        UserResponsableId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
        //        //        UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")
        //        //    },
        //        //    new MyTask
        //        //    {
        //        //        Id = Guid.NewGuid(),
        //        //        Title = "Tarefa 02",
        //        //        Description = "Descrição da tarefa 02",
        //        //        Created = DateTime.UtcNow,
        //        //        CompletionDate = DateTime.UtcNow.AddDays(3),
        //        //        UserResponsableId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
        //        //        UserId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE")
        //        //    },
        //        //    new MyTask
        //        //    {
        //        //        Id = Guid.NewGuid(),
        //        //        Title = "Tarefa 03",
        //        //        Description = "Descrição da tarefa 03",
        //        //        Created = DateTime.UtcNow,
        //        //        CompletionDate = DateTime.UtcNow.AddDays(3),
        //        //        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
        //        //        UserId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE")
        //        //    },
        //        //    new MyTask
        //        //    {
        //        //        Id = Guid.NewGuid(),
        //        //        Title = "Tarefa 04",
        //        //        Description = "Descrição da tarefa 04",
        //        //        Created = DateTime.UtcNow,
        //        //        CompletionDate = DateTime.UtcNow.AddDays(3),
        //        //        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
        //        //        UserId = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492")
        //        //    },
        //        //    new MyTask
        //        //    {
        //        //        Id = Guid.NewGuid(),
        //        //        Title = "Tarefa 05",
        //        //        Description = "Descrição da tarefa 05",
        //        //        Created = DateTime.UtcNow,
        //        //        CompletionDate = DateTime.UtcNow.AddDays(3),
        //        //        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
        //        //        UserId = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492")
        //        //    }
        //        //);
        //        //}
        //    }

        //    context.SaveChanges();
        }
    }
}
