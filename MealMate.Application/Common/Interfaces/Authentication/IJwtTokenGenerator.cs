namespace MealMate.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userID, string firstName, string lastName);
}
