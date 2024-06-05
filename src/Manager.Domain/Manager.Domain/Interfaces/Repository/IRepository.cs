namespace DefaultNamespace;

public interface IRepository<T> : IDisposible where T : base
{
    IUnitOfWork unitOfWork{
        get;
    }
}