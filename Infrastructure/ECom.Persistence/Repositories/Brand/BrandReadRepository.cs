using ECom.Application.Repositories.Basket;
using ECom.Application.Repositories.Brand;

namespace ECom.Persistence.Repositories.Brand;

public class BrandReadRepository : ReadRepository<Domain.Entities.Brand>, IBrandReadRepository
{
    public BrandReadRepository(EComDbContext context) : base(context)
    {
    }
}