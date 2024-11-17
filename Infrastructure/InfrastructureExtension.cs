using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<UserRepository>().AddScoped<CodeRepository>();
    }
}