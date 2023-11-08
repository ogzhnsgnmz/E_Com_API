using ECom.Domain.Common;
using ECom.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain
{
    public class Offer : BaseEntity
    {
        [Precision(14, 2)]
        public decimal OfferPrice { get; set; }
        public bool IsAccepted { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
