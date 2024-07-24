using MealMate.Domain.Entities;

namespace MealMate.Application.Services.Authentication;

public record class AuthenticationResult(User user, string token);
