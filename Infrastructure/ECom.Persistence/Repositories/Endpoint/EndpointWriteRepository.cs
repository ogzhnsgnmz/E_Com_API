using ECom.Application.Repositories.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Endpoint
{
    public class EndpointWriteRepository : WriteRepository<ECom.Domain.Entities.Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(EComDbContext context) : base(context)
        {
        }
    }
}
