using ECom.Application.Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Brand
{
    public class BrandWriteRepository : WriteRepository<Domain.Entities.Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
