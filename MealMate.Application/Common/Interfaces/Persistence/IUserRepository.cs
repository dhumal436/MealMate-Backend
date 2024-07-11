using MealMate.Domain.Entities;

namespace MealMate.Application.Interface.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
