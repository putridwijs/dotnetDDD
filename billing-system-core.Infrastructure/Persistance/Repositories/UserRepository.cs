using billing_system_core.Application.Common.Interface.Persistence;
using billing_system_core.Domain.Entities;

namespace billing_system_core.Infrastructure.Persistance.Repositories;

public class UserRepository: IUserRepository
{
    private static readonly List<User> _users = new ();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}