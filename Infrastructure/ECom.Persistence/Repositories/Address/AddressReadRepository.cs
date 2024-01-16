using ECom.Application.Repositories.File;
using ECom.Application.Repositories.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ECom.Persistence.Repositories.Address
{
    public class AddressReadRepository : ReadRepository<Domain.Entities.Address>, IAddressReadRepository
    {
        public AddressReadRepository(EComDbContext context) : base(context)
        {
            
        }
        public async Task<Domain.Entities.Address> GetByUserIdAsync(string UserId, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.UserId == Guid.Parse(UserId));
        }
    }
}
