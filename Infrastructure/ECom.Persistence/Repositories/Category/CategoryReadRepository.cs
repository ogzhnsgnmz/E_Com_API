using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
