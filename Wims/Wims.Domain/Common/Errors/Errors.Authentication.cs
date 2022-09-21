using ErrorOr;

namespace Wims.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "Auth.InvalidCredentials",
                description: "Invalid Credentials");

            public static Error IncorrectPassword => Error.Validation(
                code: "Auth.IncorrectPassword",
                description: "Incorrect Password");
        }
    }
}
