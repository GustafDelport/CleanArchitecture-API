using ErrorOr;
using MediatR;
using Wims.Application.Common.Interfaces.Authentication;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Application.Authentication.Common;
using Wims.Domain.Common.Errors;
using Wims.Domain.Entities;

namespace Wims.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            //Check if User Exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            //Check if password is correct
            if (user.Password != query.Password)
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
