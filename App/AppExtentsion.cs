using App.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App;

public static class AppExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<UserService>().AddScoped<CodeService>().AddScoped<AuthService>();
    }
}