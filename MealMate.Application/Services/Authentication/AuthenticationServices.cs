using System.Net;
using MealMate.Application.Common.Interface.Authentication;
using MealMate.Application.Services.Authentication;

namespace MealMate.Application;

public class AuthenticationServices : IAuthenticationServices
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), email, password);
        return new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastName);
        return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
    }
}
