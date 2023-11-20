﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Persistence.Repositories.Color
{
    public class ColorReadRepository : ReadRepository<Domain.Entities.Color>, IColorReadRepository
    {
        public ColorReadRepository(EComDbContext context) : base(context)
        {
        }
    }
}