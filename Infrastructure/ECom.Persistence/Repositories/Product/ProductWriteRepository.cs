using ECom.Application.Repositories.Product;

namespace ECom.Persistence.Repositories.Product;

public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
{
    public ProductWriteRepository(EComDbContext context) : base(context)
    {
    }
}
