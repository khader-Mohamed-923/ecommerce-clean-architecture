using ECommerce.Domain.Repositories;
using ECommerce.Infrastructure.Persistence.DbContexts;
using ECommerce.Infrastructure.Persistence.Interceptors;
using ECommerce.Infrastructure.Persistence.Seeders;
using ECommerce.Infrastructure.Repositories;
using ECommerce.Infrastructure.Caching;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Infrastructure.Identity;
using ECommerce.Application.Common.Interfaces;
using ECommerce.Application.Common.Settings;
using ECommerce.Infrastructure.Payments;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IAuditInterceptor, AuditInterceptor>();
        services.AddSingleton<ISoftDeleteInterceptor, SoftDeleteInterceptor>();

        services.AddDbContext<StoreDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));  
        
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISeeder, BrandSeeder>();
        services.AddScoped<ISeeder, TypeSeeder>();
        services.AddScoped<ISeeder, ProductSeeder>();
        services.AddScoped<ISeeder, DeliveryMethodSeeder>();
        services.AddScoped<SeederCoordinator>();
        
        // Caching
        services.AddSingleton<CacheEntryPolicyValidator>();
#pragma warning disable EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        services.AddHybridCache();
#pragma warning restore EXTEXP0018 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
        services.AddScoped(typeof(ICachedAggregateStore<>), typeof(HybridCacheAggregateStore<>));
        services.AddScoped<IBasketStore, HybridBasketStore>();

        services.Configure<ECommerce.Application.Common.Settings.CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        services.AddScoped<ECommerce.Application.Common.Interfaces.IAttachmentService, ECommerce.Infrastructure.Services.AttachmentService>();

        services.AddDbContext<AppIdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), sql =>
                    sql.MigrationsHistoryTable("__IdentityMigrationsHistory", "identity"))
                .EnableSensitiveDataLogging();
        });

        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()
            ?? throw new InvalidOperationException($"Configuration section '{JwtSettings.SectionName}' is missing.");

        if (string.IsNullOrWhiteSpace(jwtSettings.Secret) || jwtSettings.Secret.Length < 32)
            throw new InvalidOperationException("Jwt:Secret must be at least 32 characters.");

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

        services.AddAuthorization();
        services.AddHttpContextAccessor();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IEmailVerificationCodeStore, HybridEmailVerificationCodeStore>();

        services.Configure<EmailVerificationSettings>(
            configuration.GetSection(EmailVerificationSettings.SectionName));

        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.SectionName));
        var emailSettings = configuration.GetSection(EmailSettings.SectionName).Get<EmailSettings>()
            ?? throw new InvalidOperationException(
                $"Configuration section '{EmailSettings.SectionName}' is missing.");

        services
            .AddFluentEmail(emailSettings.FromEmail, emailSettings.FromName)
            .AddSmtpSender(emailSettings.Host, emailSettings.Port);

        services.AddScoped<IEmailSender, FluentEmailSender>();

        services.AddScoped<ISeeder, IdentitySeeder>();

        services.Configure<StripeSettings>(configuration.GetSection(StripeSettings.SectionName));
        services.AddScoped<IPaymentService, StripePaymentService>();

        return services;
    }
}
