using System.Data;
using Google.Apis.Auth.AspNetCore3;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Npgsql;

namespace App.Configs;

public static class BuilderConfig
{
    public static void ConfigureServices(this IServiceCollection services, string clientId, string clientSecret,
        string connectionString)
    {
        services.AddRepositories();
        services.AddServices();
        services.AddScoped<UnitOfWork>();
        services
            .AddAuthentication(o =>
            {
                o.DefaultChallengeScheme =GoogleOpenIdConnectDefaults.AuthenticationScheme;
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogleOpenIdConnect(options =>
            {
                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
            });
        services.AddDbContext<MyDbContext>(options => options.UseNpgsql(connectionString));
        services.AddAuthorization();
        services.AddControllers();
    }
}