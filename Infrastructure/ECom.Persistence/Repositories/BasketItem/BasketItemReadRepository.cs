﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.BasketItem
{
    public class BasketItemReadRepository : ReadRepository<Domain.Entities.BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}
