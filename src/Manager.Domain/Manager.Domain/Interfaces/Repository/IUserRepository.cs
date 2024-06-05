using Manager.Domain.Entities;

namespace Manager.Domain.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> FindByEmail(string email);
    void Add(User user);
    Task<bool> IsEmailInUse(string email);
}