using billing_system_core.Domain.Entities;

namespace billing_system_core.Application.Common.Interface.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}