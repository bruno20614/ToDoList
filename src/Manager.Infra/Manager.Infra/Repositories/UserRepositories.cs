using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collection.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Interfaces;

public class UserRepositories : IUserRepsoritory
{
    private readonly ApplicationDbContext  _context;

	public UserRepositories
	{
		_context = context;
	}
	
	public IUnitOfWork UnitOfWork => _context;

	public async Task<User> FindByEmail(string email)
	{	
		return await _context.Users
		.FistOrDefaultAsync(u => u.Email == email);
	}
	
	public void Add(User user)
	{
		_context.Users.Add(user);
		_context.SaveChanges();
	}

	public async Task<bool> IsEmailInUse(string email)
	{
		return await _context.Users
		.AnyAsync(u => u.Email ==email);
	}
	
	public void Dispose()
    {
        _context?.Dispose();
    }

}