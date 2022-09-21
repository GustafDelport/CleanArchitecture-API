using Mapster;
using Wims.Application.Authentication.Commands.Register;
using Wims.Application.Authentication.Common;
using Wims.Application.Authentication.Queries.Login;
using Wims.Contracts.Authentication;

namespace Wims.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //Redundent for now
            config.NewConfig<RegisterRequest, RegisterCommand>();

            //Redundent for now
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
