using MealMate.Application.Common.Interface.Authentication;
using MealMate.Application.Interface.Services;
using MealMate.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using MealMate.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using MealMate.Application.Interface.Persistence;
using MealMate.Infrastructure.Persistence;
namespace MealMate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        //Inject Dependency here
        services.Configure<JWTSettings>(configuration.GetSection(JWTSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
