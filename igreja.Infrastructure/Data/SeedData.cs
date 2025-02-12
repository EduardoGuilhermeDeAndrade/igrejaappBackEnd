using igreja.Domain.Models;

namespace igreja.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Id = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
                        Username = "admin",
                        Email = "admin@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"), // Criptografa a senha
                        Role = "Admin",
                        Created = DateTime.UtcNow,
                        IsResponsableMyTask = true
                    },
                    new User
                    {
                        Id = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
                        Username = "user",
                        Email = "user@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
                        Role = "User",
                        Created = DateTime.UtcNow,
                        IsResponsableMyTask = false
                    },
                    new User
                    {
                        Id = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492"),
                        Username = "userA",
                        Email = "userA@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
                        Role = "User",
                        Created = DateTime.UtcNow,
                        IsResponsableMyTask = false
                    },
                    new User
                    {
                        Id = Guid.Parse("30C87EFC-39B6-4A4E-8BF8-2B14FC665384"),
                        Username = "userB",
                        Email = "userB@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("user123"), // Criptografa a senha
                        Role = "User",
                        Created = DateTime.UtcNow,
                        IsResponsableMyTask = false
                    }
                );

            context.MyTasks.AddRange(
                    new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Tarefa 01",
                        Description = "Descrição da tarefa 01",
                        Created = DateTime.UtcNow,
                        CompletionDate = DateTime.UtcNow.AddDays(3),
                        UserResponsableId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
                        UserId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9")                        
                    },
                    new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Tarefa 02",
                        Description = "Descrição da tarefa 02",
                        Created = DateTime.UtcNow,
                        CompletionDate = DateTime.UtcNow.AddDays(3),
                        UserResponsableId = Guid.Parse("2B4B17FA-8C77-4DDE-B0BF-F50DE15839D9"),
                        UserId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE")
                    },
                    new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Tarefa 03",
                        Description = "Descrição da tarefa 03",
                        Created = DateTime.UtcNow,
                        CompletionDate = DateTime.UtcNow.AddDays(3),
                        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
                        UserId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE")
                    },
                    new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Tarefa 04",
                        Description = "Descrição da tarefa 04",
                        Created = DateTime.UtcNow,
                        CompletionDate = DateTime.UtcNow.AddDays(3),
                        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
                        UserId = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492")
                    },
                    new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Title = "Tarefa 05",
                        Description = "Descrição da tarefa 05",
                        Created = DateTime.UtcNow,
                        CompletionDate = DateTime.UtcNow.AddDays(3),
                        UserResponsableId = Guid.Parse("9BBE5716-924A-47F4-9FA1-335D0B3A9BAE"),
                        UserId = Guid.Parse("E5A1BB90-8DAB-45D2-B000-6E732254D492")
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
