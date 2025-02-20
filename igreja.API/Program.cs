using FluentValidation;
using FluentValidation.AspNetCore;
//using igreja.Application.Validations;
//using igreja.Application.Validators;
using igreja.CrossCutting.IoC.DependencyInjection;
using igreja.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Reflection;
using igreja.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjection(builder.Configuration);

// Configurações para autenticação com JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token validated");
                Console.WriteLine($"User ID from token: {context.Principal?.FindFirst(ClaimTypes.Name)?.Value}");
                Console.WriteLine($"User ID from token: {context.Principal?.FindFirst("userId")?.Value}");
                Console.WriteLine($"Tenant ID from token: {context.Principal?.FindFirst("tenantId")?.Value}");


                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adiciona o FluentValidation com suporte à validação automática
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

// Validadores de DTO
//builder.Services.AddValidatorsFromAssemblyContaining<MyTaskDtoValidator>();

//Validador de entidade
//builder.Services.AddValidatorsFromAssemblyContaining<MyTaskValidator>();


// Configurações do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Igreja API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no campo."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}
        }
    });

    // Adiciona suporte à documentação XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    // Adiciona suporte às anotações do Swashbuckle
    c.EnableAnnotations();
});

builder.Services.AddControllers();

var app = builder.Build();

// Chamando o SeedData
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Executa as migrações

    context.Database.Migrate();

    // Inicializa os dados

    SeedData.Initialize(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();//Exibe as mensagens de erro detalhadas e mensagens
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty; // Faz o Swagger abrir automaticamente na raiz
    });
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
