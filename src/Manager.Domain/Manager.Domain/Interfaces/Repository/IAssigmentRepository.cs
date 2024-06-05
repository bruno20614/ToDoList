using Manager.Domain.Entities;
using Manager.Domain.AssigmentFilter;

namespace Manager.Domain.Repository.Interfaces;

public interface IAssigmentRepository : IRepository<assigment>
{
    Task<IPagedResult<Assignment>> Search(Guid userId, AssignmentFilter filter, int perPage = 10, int page = 1, Guid? listId = null);
	Task<Assigment> GetById(Guid id,Guid userId);
	void Add(Assigment assigment);
	void Edit(Assigment assigment);
	void Delete(Assigment assigment);
}