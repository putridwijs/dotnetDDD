using billing_system_core.Domain.Entities;

namespace billing_system_core.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);