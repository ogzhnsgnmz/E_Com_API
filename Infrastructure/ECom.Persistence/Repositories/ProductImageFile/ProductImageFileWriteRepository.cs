using ECom.Application.Repositories.ProductImageFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.ProductImageFile
{
    public class ProductImageFileWriteRepository : WriteRepository<Domain.ProductImageFile>, IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
