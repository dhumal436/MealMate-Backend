using FluentResults;
using MealMate.Application.Common.Error;
using MealMate.Application.Services.Authentication;
using MealMate.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MealMate.Api.Controller;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private IAuthenticationServices _authenticationServices;

    public AuthenticationController(IAuthenticationServices authenticationServices)
    {
        _authenticationServices = authenticationServices;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        Result<AuthenticationResult> registrationResult = _authenticationServices.Register(
            registerRequest.firstName,
            registerRequest.lastName,
            registerRequest.email,
            registerRequest.password);
            if(registrationResult.IsSuccess) return MapAuthenticationResult(registrationResult.Value);
            var firstError = registrationResult.Errors.First();
            if(firstError is DuplicateEmailError) return Problem(statusCode:StatusCodes.Status409Conflict, detail:firstError.Message);

            return Problem();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationServices.Login(
                    loginRequest.email,
                    loginRequest.password);
        return  MapAuthenticationResult(authResult.Value); 
    }

    private OkObjectResult MapAuthenticationResult(AuthenticationResult authResult)
    {
        return Ok(new AuthenticationResponse(
                    authResult.user.id,
                    authResult.user.FirstName,
                    authResult.user.LastName,
                    authResult.user.Email,
                    authResult.token)
                    );
    }
}
