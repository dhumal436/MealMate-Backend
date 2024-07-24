using ErrorOr;
using FluentResults;
using MealMate.Application.Common.Error;
using MealMate.Application.Services.Authentication;
using MealMate.Application.Services.Authentication.Command;
using MealMate.Application.Services.Authentication.Query;
using MealMate.Contracts.Authentication;
using MealMate.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace MealMate.Api.Controller;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private IAuthenticationCommandServices _authenticationCommandServices;
    private IAuthenticationQueryServices _authenticationQueryServices;

    public AuthenticationController(IAuthenticationCommandServices authenticationCommandServices, IAuthenticationQueryServices authenticationQueryServices)
    {
        _authenticationCommandServices = authenticationCommandServices;
        _authenticationQueryServices=authenticationQueryServices;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        ErrorOr<AuthenticationResult> registrationResult = _authenticationCommandServices.Register(
            registerRequest.firstName,
            registerRequest.lastName,
            registerRequest.email,
            registerRequest.password
            );

             return registrationResult.MatchFirst(
                registrationResult => MapAuthenticationResult(registrationResult), 
                firstError => Problem(statusCode:StatusCodes.Status409Conflict, title: firstError.Description)
                );

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationQueryServices.Login(
                    loginRequest.email,
                    loginRequest.password);

                if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                {
                    return Problem(
                        statusCode:StatusCodes.Status401Unauthorized,
                        title: authResult.FirstError.Description
                    );
                }

                    return authResult.Match(
                        authResult => MapAuthenticationResult(authResult),
                        errors => Problem(errors)
                    );
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
