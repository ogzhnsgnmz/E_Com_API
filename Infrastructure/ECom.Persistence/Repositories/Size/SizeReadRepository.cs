using ECom.Application.Repositories.File;
using ECom.Application.Repositories.Size;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Size
{
    public class SizeReadRepository : ReadRepository<Domain.Entities.Size>, ISizeReadRepository
    {
        public SizeReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
