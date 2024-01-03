using ECom.Application.Repositories.Attribute;

namespace ECom.Persistence.Repositories.Attribute
{
    public class AttributeWriteRepository : WriteRepository<Domain.Entities.Attribute>, IAttributeWriteRepository
    {
        public AttributeWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
