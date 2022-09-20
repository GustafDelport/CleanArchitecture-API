using OneOf;
using Wims.Application.Common.Errors;
using Wims.Application.Common.Interfaces.Authentication;
using Wims.Application.Common.Interfaces.Persistance;
using Wims.Domain.Entities;

namespace Wims.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public OneOf<AuthenticationResult, DuplicateEmailError> Register(string firstName, string lastName, string email, string password)
        {
            //Check if user exists
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                //throw new DuplicateEmailException();
                return new DuplicateEmailError();
            }

            //Persits user to repository
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            //Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            //Check if User Exists
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exists");
            }

            //Check if password is correct
            if (user.Password != password)
            {
                throw new Exception("Incorrect Password");
            }

            //Generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
