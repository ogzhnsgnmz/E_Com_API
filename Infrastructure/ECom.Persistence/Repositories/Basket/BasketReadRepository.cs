using ECom.Application.Repositories.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Basket
{
    public class BasketReadRepository : ReadRepository<Domain.Basket>, IBasketReadRepository
    {
        public BasketReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
