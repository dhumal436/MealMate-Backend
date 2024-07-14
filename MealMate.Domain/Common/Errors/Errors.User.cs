using ErrorOr;

namespace MealMate.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateError => Error.Conflict(code:"User.DuplicateEmail", description:"Email is already in use!");
    }
}
