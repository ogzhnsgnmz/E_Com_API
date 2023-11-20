using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Color
{
    public class BaseFilesWriteRepository : WriteRepository<Domain.Entities.Color>, IColorWriteRepository
    {
        public BaseFilesWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
