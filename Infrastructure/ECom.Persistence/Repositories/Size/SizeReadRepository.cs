using ECom.Application.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Size
{
    public class SizeReadRepository : ReadRepository<Domain.Size>, ISizeReadRepository
    {
        public SizeReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
