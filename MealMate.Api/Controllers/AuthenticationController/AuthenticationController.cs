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
        var authResult = _authenticationServices.Register(
            registerRequest.firstName,
            registerRequest.lastName,
            registerRequest.email,
            registerRequest.password);
        return Ok(new AuthenticationResponse(
            authResult.id,
            authResult.firstName,
            authResult.lastName,
            authResult.email,
            authResult.token)
            );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationServices.Login(
                    loginRequest.email,
                    loginRequest.password);
        return Ok(new AuthenticationResponse(
            authResult.id,
            authResult.firstName,
            authResult.lastName,
            authResult.email,
            authResult.token)
            );
    }
}
