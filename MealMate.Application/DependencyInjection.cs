using MealMate.Application.Services.Authentication.Command;
using MealMate.Application.Services.Authentication.Query;
using Microsoft.Extensions.DependencyInjection;

namespace MealMate.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandServices, AuthenticationCommandServices>();
        return services.AddScoped<IAuthenticationQueryServices, AuthenticationQueryServices>();
    }
}
