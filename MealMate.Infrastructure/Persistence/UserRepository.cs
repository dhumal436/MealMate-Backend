using MealMate.Application.Interface.Persistence;
using MealMate.Domain.Entities;

namespace MealMate.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly static List<User> _user = new();
    public void Add(User user)
    {
        _user.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _user.SingleOrDefault(i => i.Email == email);
    }
}
