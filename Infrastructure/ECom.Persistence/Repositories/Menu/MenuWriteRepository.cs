using ECom.Application.Repositories.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Menu
{
    public class MenuWriteRepository : WriteRepository<ECom.Domain.Entities.Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
