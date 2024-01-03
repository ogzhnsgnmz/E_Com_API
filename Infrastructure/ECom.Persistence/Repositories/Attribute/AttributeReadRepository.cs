using ECom.Application.Repositories.Attribute;

namespace ECom.Persistence.Repositories.Attribute;

public class AttributeReadRepository : ReadRepository<Domain.Entities.Attribute>, IAttributeReadRepository
{
    public AttributeReadRepository(EComDbContext context) : base(context)
    {
    }
}