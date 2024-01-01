namespace ECom.Application.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    Task SaveAsync();
}
