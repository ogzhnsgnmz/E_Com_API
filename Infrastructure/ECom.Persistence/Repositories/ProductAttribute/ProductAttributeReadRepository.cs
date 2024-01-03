using ECom.Application.Repositories.ProductAttribute;

namespace ECom.Persistence.Repositories.ProductAttribute;

public class ProductAttributeReadRepository : ReadRepository<Domain.Entities.ProductAttribute>, IProductAttributeReadRepository
{
    public ProductAttributeReadRepository(EComDbContext context) : base(context)
    {
    }
}
