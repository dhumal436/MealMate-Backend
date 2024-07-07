namespace MealMate.Contracts.Authentication;

public record class LoginRequest(string email, string password);
