using ECom.Application.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Order
{
    public class OrderWriteRepository : WriteRepository<Domain.Entities.Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
