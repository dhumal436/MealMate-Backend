using ErrorOr;

namespace MealMate.Application.Services.Authentication.Command;

public interface IAuthenticationCommandServices
{
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
