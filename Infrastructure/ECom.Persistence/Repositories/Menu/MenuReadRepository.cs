using ECom.Application.Repositories.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Menu
{
    public class MenuReadRepository : ReadRepository<ECom.Domain.Entities.Menu>, IMenuReadRepository
    {
        public MenuReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
