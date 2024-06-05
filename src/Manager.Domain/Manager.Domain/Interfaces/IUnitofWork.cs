namespace Manager.Domain.Interface

public interface IUnitofWork
{
   Task<bool> Commit();
   
}