using ECom.Application.Repositories.Basket;

namespace ECom.Persistence.Repositories.Basket
{
    public class BasketReadRepository : ReadRepository<Domain.Entities.Basket>, IBasketReadRepository
    {
        public BasketReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
