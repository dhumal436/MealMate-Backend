namespace MealMate.Contracts.Authentication;

public record class AuthenticationResponse(Guid id,string firstName, string lastName, string email, string token);
