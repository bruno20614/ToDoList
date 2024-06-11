using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collection.Generic;
using System.Threading.Tasks;
using Manager.Domain.AssigmentFilter;
using System;
using System.Threading.Tasks;

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
	    var query = _context.Assigments
		    .AsNoTrackingWithIdentityResolution();
            .AsQueryable();
        
        ApplyFilter(userId, filter, ref query, listId);
        
        ApplyOrdenation(filter, ref query);

        var result = new IPagedResult<Assigment>
        {
            Items = await query.Skip((page - 1) * perPage).Take(perPage).ToListAsync(),
            Total = await query.CountAsync(),
            Page = page,
            PerPage = perPage
        };
        var pageCount = (double) result.Total / perPage;
        result.PageCount = (int)Math.Ceiling(pageCount);

        return result;
    }
    
    public async Task<Assignment> GetById(Guid id, Guid userId)
    {
        return await _context.Assignments
            .FirstOrDefaultAsync(c => c.UserId == userId && c.Id == id);
    }

    public void Add(Assignment assignment)
    {
        _context.Assignments.Add(assignment);
    }

    public void Edit(Assignment assignment)
    {
        _context.Assignments.Update(assignment);
    }

    public void Delete(Assignment assignment)
    {
        _context.Assignments.Remove(assignment);
    }
    
    private static void ApplyFilter(Guid userId, AssignmentFilter filter, ref IQueryable<Assignment> query, Guid? listId = null)
    {
        if (!string.IsNullOrWhiteSpace(filter.Description))
            query = query.Where(c => c.Description.Contains(filter.Description));

        if (filter.Concluded.HasValue)
            query = query.Where(c => c.Concluded == filter.Concluded.Value);

        if (filter.StartDeadline.HasValue)
            query = query.Where(c => c.Deadline >= filter.StartDeadline.Value);
        
        if (filter.EndDeadline.HasValue)
            query = query.Where(c => c.Deadline <= filter.EndDeadline.Value);
        
        if (listId.HasValue)
        {
            query = query
                .Where(c => c.AssignmentListId == listId)
                .Where(c => c.AssignmentList.UserId == userId);
        }

        if (!listId.HasValue)
        {
            query = query
                .Where(c => c.AssignmentListId == null)
                .Where(c => c.UserId == userId);
        }
    }
    
    private static void ApplyOrdenation(AssignmentFilter filter, ref IQueryable<Assignment> query)
    {
        if (filter.OrderDir.ToLower().Equals("asc"))
        {
            query = filter.OrderBy.ToLower() switch
            {
                "description" => query.OrderBy(c => c.Description),
                "concluded" => query.OrderBy(c => c.Concluded),
                "deadline" => query.OrderBy(c => c.Deadline),
                _ => query.OrderBy(c => c.CreatedAt)
            };
            return;
        }
        
        query = filter.OrderBy.ToLower() switch
        {
            "description" => query.OrderByDescending(c => c.Description),
            "concluded" => query.OrderByDescending(c => c.Concluded),
            "deadline" => query.OrderByDescending(c => c.Deadline),
            _ => query.OrderByDescending(c => c.CreatedAt)
        };
    }
    
    public void Dispose()
    {
        _context?.Dispose();
    }
}