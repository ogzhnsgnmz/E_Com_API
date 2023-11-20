using ECom.Application.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Order
{
    public class OrderReadRepository : ReadRepository<Domain.Entities.Order>, IOrderReadRepository
    {
        public OrderReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
