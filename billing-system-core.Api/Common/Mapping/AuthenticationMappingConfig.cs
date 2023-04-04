using billing_system_core.Application.Authentication.Commands.Register;
using billing_system_core.Application.Authentication.Common;
using billing_system_core.Application.Authentication.Queries.Login;
using billing_system_core.Contracts.Authentication;

using Mapster;

namespace billing_system_core.Api.Common.Mapping;

public class AuthenticationMappingConfig: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}