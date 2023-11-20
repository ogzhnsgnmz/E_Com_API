using ECom.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
