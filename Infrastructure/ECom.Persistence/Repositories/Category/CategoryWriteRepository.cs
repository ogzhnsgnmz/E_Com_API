using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
