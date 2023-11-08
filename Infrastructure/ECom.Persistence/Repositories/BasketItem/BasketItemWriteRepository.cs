using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.BasketItem
{
    public class BasketItemWriteRepository : WriteRepository<Domain.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
