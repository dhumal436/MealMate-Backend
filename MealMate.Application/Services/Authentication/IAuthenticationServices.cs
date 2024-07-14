using ErrorOr;
using FluentResults;
using MealMate.Application.Common.Error;

namespace MealMate.Application.Services.Authentication;

public interface IAuthenticationServices
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
}
