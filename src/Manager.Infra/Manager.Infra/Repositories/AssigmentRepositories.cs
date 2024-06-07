using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collection.Generic;
using System.Threading.Tasks;
using Manager.Domain.AssigmentFilter;

namespace Manager.Infra.Repositories;

public class AssigmentRepositories : IAssigmentRepository
{
    private readonly ApplicationDbContext  _context;

    public AssigmentRepositories
    {
        context = _context;
    }
    
    public IUnityOfWORK UnityOfWork _context;
    
    
    public async Task<IPagedResult<Assigment>> Search(Guid userId,AssigmentFilter)
	{
		var query= _context.Assigments
		.AsNoTrackingWithIdent
	}
    
    Task<IPagedResult<Assignment>> Search(Guid userId, AssignmentFilter filter, int perPage = 10, int page = 1, Guid? listId = null);
    Task<Assigment> GetById(Guid id,Guid userId);
    void Add(Assigment assigment);
    void Edit(Assigment assigment);
    void Delete(Assigment assigment);
}
}