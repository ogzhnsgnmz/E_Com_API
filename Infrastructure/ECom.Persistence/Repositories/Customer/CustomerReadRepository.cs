using ECom.Application.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Customer
{
    public class CustomerReadRepository : ReadRepository<Domain.Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
