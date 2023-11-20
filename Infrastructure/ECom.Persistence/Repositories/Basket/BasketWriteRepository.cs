using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Basket
{
    public class BasketWriteRepository : WriteRepository<Domain.Entities.Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
