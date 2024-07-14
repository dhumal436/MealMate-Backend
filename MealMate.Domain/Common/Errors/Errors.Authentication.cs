using ErrorOr;

namespace MealMate.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code:"User.InvalidCredentials", description:"InvalidCredentials");
    }
}
