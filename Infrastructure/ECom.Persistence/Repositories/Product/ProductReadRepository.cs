using ECom.Application.Repositories.Product;

namespace ECom.Persistence.Repositories.Product;

public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
{
    public ProductReadRepository(EComDbContext context) : base(context)
    {
    }
}
