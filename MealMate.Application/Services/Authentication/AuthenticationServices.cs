using System.Net;
using FluentResults;
using MealMate.Application.Common.Error;
using MealMate.Application.Common.Interface.Authentication;
using MealMate.Application.Interface.Persistence;
using MealMate.Application.Services.Authentication;
using MealMate.Domain.Entities;

namespace MealMate.Application;

public class AuthenticationServices : IAuthenticationServices
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User Not Found");
        }
        if(password != user.Password)
        {
            throw new Exception("Password Not Matched!");
        }
        var token = _jwtTokenGenerator.GenerateToken(user.id, user.FirstName, user.LastName);
        return new AuthenticationResult(user, token);
    }

    public Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
        }
        var user = new User{
           FirstName = firstName,
            LastName = lastName,
            Email = email,
             Password = password
        };
        _userRepository.Add(user);
        var token = _jwtTokenGenerator.GenerateToken(user.id, firstName, lastName);
        return new AuthenticationResult(user, token);
    }
}
