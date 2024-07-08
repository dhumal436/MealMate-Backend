using MealMate.Application.Interface.Services;

namespace MealMate.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime utcNow => DateTime.UtcNow;
}
