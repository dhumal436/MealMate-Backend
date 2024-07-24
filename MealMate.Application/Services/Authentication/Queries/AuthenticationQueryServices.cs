using ErrorOr;
using MealMate.Application.Common.Interface.Authentication;
using MealMate.Application.Interface.Persistence;
using MealMate.Application.Services.Authentication;
using MealMate.Domain.Common.Errors;
using MealMate.Domain.Entities;

namespace MealMate.Application.Services.Authentication.Query;

public class AuthenticationQueryServices : IAuthenticationQueryServices
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryServices(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        if(password != user.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user.id, user.FirstName, user.LastName);
        return new AuthenticationResult(user, token);
    }
}
