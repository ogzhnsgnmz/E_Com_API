using ECom.Application.Repositories.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<ECom.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
