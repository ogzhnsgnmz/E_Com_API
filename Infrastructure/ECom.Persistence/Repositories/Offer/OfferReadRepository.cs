using ECom.Application.Repositories.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Offer
{
    public class OfferReadRepository : ReadRepository<Domain.Offer>, IOfferReadRepository
    {
        public OfferReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
