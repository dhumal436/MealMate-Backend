using MealMate.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace MealMate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddScoped<IAuthenticationServices, AuthenticationServices>();
    }
}
