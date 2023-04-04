using billing_system_core.Application.Authentication.Commands.Register;
using billing_system_core.Application.Authentication.Common;
using billing_system_core.Application.Authentication.Queries.Login;
using billing_system_core.Contracts.Authentication;
using billing_system_core.Domain.Common.Errors;
using ErrorOr;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace billing_system_core.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
        authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authResult.Value)),
        errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }
        
        return authResult.Match(
            authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authResult.Value)),
            errors => Problem(errors));
    }
}