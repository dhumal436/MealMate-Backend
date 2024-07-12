using FluentResults;
using MealMate.Application.Common.Error;

namespace MealMate.Application.Services.Authentication;

public interface IAuthenticationServices
{
    Result<AuthenticationResult> Login(string email, string password);
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
