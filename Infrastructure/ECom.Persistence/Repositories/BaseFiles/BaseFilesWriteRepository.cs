using ECom.Application.Repositories.BaseFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.BaseFiles
{
    public class BaseFilesWriteRepository : WriteRepository<Domain.Entities.Customer>, IBaseFilesWriteRepository
    {
        public BaseFilesWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
