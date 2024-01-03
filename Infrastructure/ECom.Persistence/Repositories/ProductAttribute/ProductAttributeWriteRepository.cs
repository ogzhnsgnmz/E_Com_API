using ECom.Application.Repositories.ProductAttribute;

namespace ECom.Persistence.Repositories.ProductAttribute;

public class ProductAttributeWriteRepository : WriteRepository<Domain.Entities.ProductAttribute>, IProductAttributeWriteRepository
{
    public ProductAttributeWriteRepository(EComDbContext context) : base(context)
    {
    }
}
