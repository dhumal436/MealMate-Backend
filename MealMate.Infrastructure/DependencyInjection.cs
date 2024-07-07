using Microsoft.Extensions.DependencyInjection;

namespace MealMate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        //Inject Dependency here
        return services;
    }
}
