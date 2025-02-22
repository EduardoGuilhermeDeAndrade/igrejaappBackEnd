﻿using igreja.Application.Interfaces;
using igreja.Application.Services;
using igreja.Domain.Interfaces;
using igreja.Domain.Interfaces.Repository;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Providers;
using igreja.Infrastructure.Repositories;
using igreja.Infrastructure.Repositories.General;
using Igreja.Application.Services;
using Igreja.Domain.Interfaces;
using Igreja.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace igreja.CrossCutting.IoC.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuração do DbContext

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Configuração do IHttpContextAccessor
            services.AddHttpContextAccessor();

            // Repositorios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IMyTaskRepository, MyTaskRepository>();
           
            services.AddScoped<IMemberRepository, MemberRepository>();
            
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<IIgrejaTenantRepository, IgrejaTenantRepository>();

            // Serviços
            services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IMyTaskService, MyTaskService>();

            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IIgrejaTenantService, IgrejaTenantService>();

            //Serviços da infraestrutura
            services.AddScoped<IAttachmentService, AttachmentService>();

            // UserContextProvider
            services.AddScoped<IUserContextProvider, UserContextProvider>();

            return services;
        }
    }
}
