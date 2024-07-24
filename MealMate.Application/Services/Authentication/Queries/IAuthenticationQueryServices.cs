using ErrorOr;

namespace MealMate.Application.Services.Authentication.Query;

public interface IAuthenticationQueryServices
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
}
