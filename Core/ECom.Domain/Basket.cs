﻿using ECom.Domain.Common;
using ECom.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class Basket : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

        public Order Order { get; set; }
    }
}
