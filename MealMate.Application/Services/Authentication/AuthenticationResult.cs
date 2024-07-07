namespace MealMate.Application.Services.Authentication;

public record class AuthenticationResult(Guid id,string firstName, string lastName, string email, string token);
