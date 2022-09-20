using ErrorOr;
using Wims.Application.Common.Interfaces.Authentication;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Services.Authentication.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Services.Authentication.Queries.Login
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //Check if User Exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //Check if password is correct
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
