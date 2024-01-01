using ECom.Application.UnitOfWork;

namespace ECom.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EComDbContext _context;  // IDbContext'i, gerçek DbContext tipinizle değiştirin

    public UnitOfWork(EComDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        // İşlemi başlat
        //_context.BeginTransaction();
    }

    public void Commit()
    {
        // İşlemi tamamla
        //_context.Commit();
    }

    public void Rollback()
    {
        // İşlemi geri al
        //_context.Rollback();
    }

    public async Task SaveAsync()
    {
        // Değişiklikleri veritabanına kaydet
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        // Gerekirse kaynakları temizle
    }
}
