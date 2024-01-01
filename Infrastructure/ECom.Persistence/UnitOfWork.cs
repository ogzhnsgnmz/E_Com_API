using ECom.Application.UnitOfWork;

namespace ECom.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EComDbContext _context;

    public UnitOfWork(EComDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _context.BeginTransactionAsync();
    }

    public void Commit()
    {
        _context.CommitTransactionAsync();
    }

    public void Rollback()
    {
        _context.RollbackTransaction();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
    }
}
