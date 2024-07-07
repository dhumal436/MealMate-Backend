using System.Net;
using MealMate.Application.Services.Authentication;

namespace MealMate.Application;

public class AuthenticationServices : IAuthenticationServices
{
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
    }
}
