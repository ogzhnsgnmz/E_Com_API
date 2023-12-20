using ECom.Application.Repositories.ComletedOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.CompletedOrder
{
    public class CompletedOrderWriteRepository : WriteRepository<ECom.Domain.Entities.CompletedOrder>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
