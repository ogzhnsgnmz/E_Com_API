using ECom.Application.Repositories.BaseFiles;
using ECom.Application.Repositories.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.BaseFiles
{
    public class BaseFilesReadRepository : ReadRepository<Domain.Customer>, IBaseFilesReadRepository
    {
        public BaseFilesReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
