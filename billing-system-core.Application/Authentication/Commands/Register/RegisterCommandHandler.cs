using billing_system_core.Application.Authentication.Common;
using billing_system_core.Application.Common.Interface.Authentication;
using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.Common.Errors;
using billing_system_core.Domain.Entities;

using ErrorOr;

using MediatR;

namespace billing_system_core.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(command.Email) != null)
            return Errors.User.DuplicateEmail;
        
        var user = new User {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        }; 
        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user); 
        return new AuthenticationResult(user, token);
    }
}