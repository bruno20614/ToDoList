using Manager.Domain.Entities;

namespace Manager.Domain.Interfaces;
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<List<User>>SearchByEmail(string email);
    Task<List<User>> SearchByName(string name);
    
}