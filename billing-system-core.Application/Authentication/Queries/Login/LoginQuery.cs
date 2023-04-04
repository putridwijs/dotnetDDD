using billing_system_core.Application.Authentication.Common;

using ErrorOr;
using MediatR;

namespace billing_system_core.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;