using ECom.Application.Repositories.File;
using ECom.Application.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Address
{
    public class AddressWriteRepository : WriteRepository<Domain.Entities.Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
