using ECom.Application.Repositories.ComletedOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.CompletedOrder
{
    public class CompletedOrderReadRepository : ReadRepository<Domain.Entities.CompletedOrder>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
