using ECom.Application.Repositories.ProductImageFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.ProductImageFile
{
    public class ProductImageFileReadRepository : ReadRepository<Domain.ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
