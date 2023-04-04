using billing_system_core.Domain.Entities;

namespace billing_system_core.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}