using ECom.Application.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<ECom.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
