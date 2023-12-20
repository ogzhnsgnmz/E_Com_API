using ECom.Application.Repositories.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Endpoint
{
    public class EndpointReadRepository : ReadRepository<ECom.Domain.Entities.Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
