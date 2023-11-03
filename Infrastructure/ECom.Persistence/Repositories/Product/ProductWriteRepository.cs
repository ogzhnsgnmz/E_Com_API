using ECom.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
