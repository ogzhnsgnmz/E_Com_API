using ECom.Application.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Customer
{
    public class CustomerWriteRepository : WriteRepository<Domain.Entities.Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
