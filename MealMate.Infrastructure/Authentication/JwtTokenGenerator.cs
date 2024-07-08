using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MealMate.Application.Common.Interface.Authentication;
using MealMate.Application.Interface.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MealMate.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    IDateTimeProvider _dateTimeProvider;
    JWTSettings _jWTSettings;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JWTSettings> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _jWTSettings = options.Value;
    }
    public string GenerateToken(Guid userID, string firstName, string lastName)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Secret)), SecurityAlgorithms.HmacSha256
        );
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userID.ToString()),
            new Claim(JwtRegisteredClaimNames.Name, firstName),
            new Claim(JwtRegisteredClaimNames.Sub, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var securityToken = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            issuer: _jWTSettings.Issuer,
            expires: _dateTimeProvider.utcNow.AddMinutes(_jWTSettings.ExpiryMinutes),
            audience:_jWTSettings.Audience
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
