namespace Manager.Domain.Interfaces.Repository;

public interface IRepository<T> : IDisposible where T : base
{
    IUnitOfWork unitOfWork{ get; }
}