using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Brand
{
    public class BrandReadRepository : ReadRepository<Domain.Brand>, IBrandReadRepository
    {
        public BrandReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
